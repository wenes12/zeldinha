using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public int totalHeath;
    public int damage;
    public float rotationSpeed;

    [Header("Atributtes")]
    public float followDistance;
    public float rangeAtk;

    private Transform player;
    private NavMeshAgent navMesh;
    private CapsuleCollider cap;
    public Transform mesh;
    public SkinnedMeshRenderer skinMesh;
    public Animator anim;

    private bool atkDelay;
    private bool hitting;
    private bool attacking;
    private bool walking;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMesh = GetComponent<NavMeshAgent>();
        cap = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalHeath > 0)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            //personagem está no raio de ação
            if (distance <= followDistance)
            {
                navMesh.isStopped = false;

                if(!attacking)
                {
                    navMesh.SetDestination(player.position);
                    anim.SetInteger("transition", 2);
                    walking = true;
                }
                

                if (distance <= navMesh.stoppingDistance)
                {
                    //PERSONAGEM ESTÁ NO RAIO DE ATAQUE
                    LookTarget();
                    StartCoroutine("Attack");
                    
                }
                else
                {
                    attacking = false;
                }
            }
            else
            {
                //personagem está fora do raio de ação
                navMesh.isStopped = true;
                anim.SetInteger("transition", 1);
                walking = false;
                attacking = false;
            }
        }
    }

    void LookTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    IEnumerator Attack()
    {
        if (!atkDelay && !hitting)
        {
            atkDelay = true;
            attacking = true;
            walking = false;
            anim.SetInteger("transition", 3);
            yield return new WaitForSeconds(0.6f);
            GetPlayer();
            atkDelay = false;
        }
    }

    void GetPlayer()
    {
        foreach(Collider c in Physics.OverlapSphere((transform.position + transform.forward * rangeAtk), rangeAtk))
        {
            if(c.gameObject.CompareTag("Player"))
            {
                //aplicar dano ao player
                c.gameObject.GetComponent<Player>().GetHit(damage);
                
            }
        }
    }

    public void GetHit(int damage)
    {
        totalHeath -= damage;

        if(totalHeath > 0)
        {
            //inimigo toma dano
            StopCoroutine("Attack");
            hitting = true;
            anim.SetInteger("transition", 4);
            StartCoroutine("Recovery");
        }
        else
        {
            //inimigo morre
            anim.SetTrigger("die");
            cap.enabled = false;
            Destroy(gameObject, 5f);
        }
    }

    IEnumerator Recovery()
    {        
        navMesh.Move(-transform.forward * 4f);

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
        anim.SetInteger("transition", 1);
        hitting = false;
        atkDelay = false;        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followDistance);
    }
}
