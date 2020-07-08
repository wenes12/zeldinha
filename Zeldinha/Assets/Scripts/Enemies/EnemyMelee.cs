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

    [Header("Atributtes")]
    public float followDistance;
    public float rangeAtk;

    private Transform player;
    private NavMeshAgent navMesh;
    private CapsuleCollider cap;
    public MeshRenderer mesh;

    private bool atkDelay;
    private bool hitting;

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

                navMesh.SetDestination(player.position);

                if (distance <= navMesh.stoppingDistance)
                {
                    //PERSONAGEM ESTÁ NO RAIO DE ATAQUE
                    StartCoroutine("Attack");
                }
            }
            else
            {
                //personagem está fora do raio de ação
                navMesh.isStopped = true;
            }
        }
    }

    IEnumerator Attack()
    {
        if (!atkDelay && !hitting)
        {
            atkDelay = true;
            yield return new WaitForSeconds(1f);
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
            hitting = true;
            StartCoroutine("Recovery");
        }
        else
        {
            //inimigo morre
        }
    }

    IEnumerator Recovery()
    {        
        navMesh.Move(-transform.forward * 4f);

        mesh.enabled = false;
        yield return new WaitForSeconds(.1f);
        mesh.enabled = true;
        yield return new WaitForSeconds(.1f);
        mesh.enabled = false;
        yield return new WaitForSeconds(.1f);
        mesh.enabled = true;

        yield return new WaitForSeconds(1f);
        hitting = false;
        atkDelay = false;        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followDistance);
    }
}
