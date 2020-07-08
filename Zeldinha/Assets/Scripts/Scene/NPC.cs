using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Sentences sentence;
    public float colliderRadious;

    public bool reading;

    // Start is called before the first frame update
    void Start()
    {
        sentence = GetComponent<Sentences>();
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayer();
    }

    void GetPlayer()
    {
        

        foreach (Collider c in Physics.OverlapSphere(transform.position, colliderRadious))
        {
            
            if (c.gameObject.CompareTag("Player") && !reading)
            {
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, colliderRadious);
    }
}
