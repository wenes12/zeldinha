using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRanged : MonoBehaviour
{

    [Header("Stats")]
    public float speed;
    public int totalHeath;
    public int damage;

    [Header("Atributtes")]
    public float followDistance;
    public float rotationSpeed;
    public float fireRate;

    private Transform player;
    private NavMeshAgent navMesh;
    private CapsuleCollider cap;
    private AudioSource audioSource;

    public Animator anim;

    public Transform mesh;
    public SkinnedMeshRenderer skinMesh;
    public GameObject fire;
    public Transform firePoint;

    private bool atkDelay;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
        cap = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.instance.playerIsAlive)
        {
            if (totalHeath > 0)
            {
                float distance = Vector3.Distance(player.position, transform.position);

                //personagem está no raio de ação
                if (distance <= followDistance)
                {
                    navMesh.isStopped = false;

                    navMesh.SetDestination(player.position);

                    if (distance <= navMesh.stoppingDistance)
                    {
                        //PERSONAGEM ESTÁ NO RAIO DE ATAQUE
                        StartCoroutine("Shot");
                        LookTarget();
                    }
                }
                else
                {
                    //personagem está fora do raio de ação
                    navMesh.isStopped = true;
                }
            }
        }
       
    }

    IEnumerator Shot()
    {
        if(!atkDelay)
        {
            atkDelay = true;
            anim.SetTrigger("atk");
            Instantiate(fire, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(fireRate);
            atkDelay = false;
        }
        
    }

    void LookTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void GetHit(int damage)
    {
        totalHeath -= damage;

        if (totalHeath > 0)
        {
            //inimigo toma dano
            audioSource.PlayOneShot(GameController.instance.hit);
            StartCoroutine("Recovery");
        }
        else
        {
            //inimigo morre
            anim.SetTrigger("die");
            audioSource.PlayOneShot(GameController.instance.hit);
            cap.enabled = false;
            GameController.instance.DecreaseEnemies();
            Destroy(gameObject, 5f);
        }
    }

    IEnumerator Recovery()
    {
        navMesh.Move(-transform.forward * 3f);

        mesh.gameObject.SetActive(false);
        skinMesh.material.color = Color.red;
        yield return new WaitForSeconds(.1f);
        mesh.gameObject.SetActive(true);
        yield return new WaitForSeconds(.1f);
        mesh.gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        mesh.gameObject.SetActive(true);
        skinMesh.material.color = Color.white;

        yield return new WaitForSeconds(1f);
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followDistance);
    }
}
