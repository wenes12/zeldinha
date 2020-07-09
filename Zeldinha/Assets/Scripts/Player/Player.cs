using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Transform cam;

    public Animator anim;
    private AudioSource audioSource;

    [Header("Atributtes")]
    [SerializeField]
    private float turnSmooth;
    private Vector3 moveDirection;
    public float smoothRootTime;
    public float speed;
    public float gravity;
    public float jumpHeight;
    private float jumpVelocity;

    private bool atkDelay;
    private bool isHit;
    private List<Transform> enemiesList = new List<Transform>();

    [Header("Stats")]
    public int lives;
    public int damage;
    public float collideRadius;

    [Header("Rerences")]
    public ParticleSystem hitEffect;
    public Transform body;
    public SkinnedMeshRenderer mesh;

    private bool attacking;
    private bool walking;

    private float sAttackTimer;
    private bool sDelay;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        if (!GameController.instance.playerIsAlive)
        {
            Move();

            InputAttack();
        }
        
    }

    void InputAttack()
    {
        //normal
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (walking)
            {
                walking = false;
                anim.SetInteger("transition", 0);
            }

            if (!walking)
                StartCoroutine("Attack");
        }

        //especial
        if(Input.GetKey(KeyCode.J) && !sDelay)
        {
            sAttackTimer += Time.deltaTime;

            if(sAttackTimer > 0.5f)
            {
                anim.SetTrigger("especial");
                hitEffect.Play();
                audioSource.PlayOneShot(GameController.instance.sword);
                moveDirection = Vector3.zero;
                sAttackTimer = 0f;
                sDelay = true;
            }
        }
    }

    void Move()
    {
        if(controller.isGrounded && !GameController.instance.isPaused)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical);

            if(direction.magnitude > 0)
            {
                if(!attacking)
                {
                    float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                    float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmooth, smoothRootTime);

                    transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

                    moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward * speed;

                    anim.SetInteger("transition", 1);
                    walking = true;
                }
                else
                {
                    walking = false;
                    moveDirection = Vector3.zero;
                }
               
            }
            else if(walking)
            {
                //player parado
                
                anim.SetInteger("transition", 0);
                moveDirection = Vector3.zero;
                walking = false;

            }

            if(Input.GetKeyDown(KeyCode.Space))
            {               
                    moveDirection.y = jumpHeight;                             

                
            }

        }
  
        
        moveDirection.y -= gravity * Time.deltaTime;


        //mover
        controller.Move(moveDirection * Time.deltaTime);
    }


    IEnumerator Attack()
    {
        if(!atkDelay && !isHit)
        {
            atkDelay = true;
            attacking = true;
            anim.SetInteger("transition", 2);
            moveDirection = Vector3.zero;

            yield return new WaitForSeconds(0.4f);
            hitEffect.Play();
            audioSource.PlayOneShot(GameController.instance.sword);

            GetEnemiesList();

            foreach(Transform e in enemiesList)
            {
                //aplicar dano ao inimigo
                EnemyMelee enemyMelee = e.GetComponent<EnemyMelee>();
                EnemyRanged enemyRanged = e.GetComponent<EnemyRanged>();

                if(enemyMelee != null)
                {
                    enemyMelee.GetHit(damage);
                }

                if (enemyRanged != null)
                {
                    enemyRanged.GetHit(damage);
                }
            }

            yield return new WaitForSeconds(0.5f);

            anim.SetInteger("transition", 0);
            attacking = false;
            atkDelay = false;
            sAttackTimer = 0f;
            sDelay = false;
        }
    }

    void GetEnemiesList()
    {
        enemiesList.Clear();
        foreach(Collider c in Physics.OverlapSphere((transform.position + transform.forward * collideRadius), collideRadius))
        {
            if(c.gameObject.CompareTag("Enemy"))
            {
                enemiesList.Add(c.transform);
            }
        }
    }

    public void GetHit(int damage)
    {
        lives -= damage;
        

        if(lives > 0)
        {
            //player toma dano
            StopCoroutine("Attack");
            audioSource.PlayOneShot(GameController.instance.hit);
            attacking = false;
            isHit = true;
            StartCoroutine("Recovery");
        }
        else
        {
            //player morre
            GameController.instance.playerIsAlive = true;
            GameController.instance.ShowGO();
        }

    }

    IEnumerator Recovery()
    {
        body.gameObject.SetActive(false);
        
        foreach(SkinnedMeshRenderer m in body.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            m.material.color = Color.red;
        }

        foreach(Material m in mesh.materials)
        {
            m.color = Color.red;
        }

        yield return new WaitForSeconds(.1f);
        body.gameObject.SetActive(true);
        yield return new WaitForSeconds(.1f);
        body.gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        body.gameObject.SetActive(true);

        foreach (SkinnedMeshRenderer m in body.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            m.material.color = Color.white;
        }

        foreach (Material m in mesh.materials)
        {
            m.color = Color.white;
        }


        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("transition", 0);
        isHit = false;
        atkDelay = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward, collideRadius);
    }

}
