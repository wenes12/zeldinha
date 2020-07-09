using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    private Sentences sentence;
    public float colliderRadious;

    public bool reading;
    public float rotationSpeed;

    private Transform player;

    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        sentence = GetComponent<Sentences>();
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayer();
    }

    void GetPlayer()
    {
        

        foreach (Collider c in Physics.OverlapSphere(transform.position, colliderRadious, layer))
        {
            
            if (c.gameObject.CompareTag("Player") && !reading)
            {
                LookTarget();
                GetComponent<NpcPatrolWaypoint>().isSpeech = true;
                GameController.instance.checkBt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.C))
                {
                    
                    GameController.instance.checkBt.SetActive(false);
                    sentence.OpenDialogue();
                    reading = true;
                }
            }

            
            
            
        }
    }

    void LookTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void CloseWindow()
    {
        GameController.instance.checkBt.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, colliderRadious);
    }
}
