using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Transform cam;

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

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine("Attack");
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
                float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmooth, smoothRootTime);

                transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

                moveDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward * speed;
            }
            else
            {
                moveDirection = Vector3.zero;

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

            yield return new WaitForSeconds(1f);
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

            yield return new WaitForSeconds(1f);
            atkDelay = false;
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
            //player ainda vivo
            isHit = true;
            StartCoroutine("Recovery");
        }
        else
        {
            //player morre

        }

    }

    IEnumerator Recovery()
    {
        yield return new WaitForSeconds(1f);

        isHit = false;
        atkDelay = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward, collideRadius);
    }

}
