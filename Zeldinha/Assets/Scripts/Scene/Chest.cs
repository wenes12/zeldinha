using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool off;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("abriu!");
        }
    }

    private void Update()
    {
        SawPlayer();
    }

    void SawPlayer()
    {
        foreach (Collider c in Physics.OverlapSphere(transform.position, 2))
        {

            if (c.gameObject.CompareTag("Player") && !off)
            {
                
                GameController.instance.checkBt.SetActive(true);

                if (Input.GetKeyDown(KeyCode.C))
                {
                    GameController.instance.isPaused = true;
                    player.OpenChest();
                    GameController.instance.checkBt.SetActive(false);
                    off = true;
                    
                }
            }




        }
    }
}
