using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRanged : MonoBehaviour
{

    [Header("Stats")]
    public float speed;
    public int totalHeath;

    [Header("Atributtes")]
    public float followDistance;
    public float rotationSpeed;
    public float fireRate;

    private Transform player;
    private NavMeshAgent navMesh;
    private CapsuleCollider cap;
    public MeshRenderer mesh;

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
        if(totalHeath > 0)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            //personagem está no raio de ação
            if(distance <= followDistance)
            {
                navMesh.isStopped = false;

                navMesh.SetDestination(player.position);

                if(distance <= navMesh.stoppingDistance)
                {
                    //PERSONAGEM ESTÁ NO RAIO DE ATAQUE
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

    IEnumerator Shot()
    {
        yield return new WaitForSeconds(fireRate);
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
            StartCoroutine("Recovery");
        }
        else
        {
            //inimigo morre
        }
    }

    IEnumerator Recovery()
    {
        navMesh.Move(-transform.forward * 3f);

        mesh.enabled = false;
        yield return new WaitForSeconds(.1f);
        mesh.enabled = true;
        yield return new WaitForSeconds(.1f);
        mesh.enabled = false;
        yield return new WaitForSeconds(.1f);
        mesh.enabled = true;

        yield return new WaitForSeconds(1f);
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followDistance);
    }
}
