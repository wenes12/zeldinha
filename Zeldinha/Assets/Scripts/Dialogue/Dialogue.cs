using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameDisplay;
    public string[] setences;
    private int index;
    public float speed;
    public string npcName;

    public GameObject continueBt;
    public GameObject dialogueObj;

    private CinemachineFreeLook cine;

    private void Start()
    {
        cine = FindObjectOfType<CinemachineFreeLook>();
    }


    // Start is called before the first frame update
    public void CallDialogue(string npcName)
    {
        index = 0;
        this.npcName = npcName;
        StartCoroutine(type(this.npcName));
    }

    private void Update()
    {
        if(setences.Length > 0)
        if(textDisplay.text == setences[index])
        {
            continueBt.SetActive(true);
        }
    }

    IEnumerator type(string npcName)
    {
        cine.m_Lens.FieldOfView = 50;
        GameController.instance.isPaused = true;
        nameDisplay.text = npcName;

        continueBt.SetActive(false);

        foreach (char letter in setences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }

    public void nextSetence()
    {
        continueBt.SetActive(false);

        if(index < setences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(type(this.npcName));
        }
        else
        {
            cine.m_Lens.FieldOfView = 80;
            textDisplay.text = "";            
            GameController.instance.isPaused = false;
            dialogueObj.SetActive(false);
            continueBt.SetActive(false);
        }
    }
}
