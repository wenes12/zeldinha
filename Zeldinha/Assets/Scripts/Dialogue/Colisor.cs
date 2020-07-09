using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisor : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<NPC>().CloseWindow();
    }
}
