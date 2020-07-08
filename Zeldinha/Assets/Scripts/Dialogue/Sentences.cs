using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentences : MonoBehaviour
{
    private Dialogue dialogue;
    public string npcName;
    public string[] speech;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = FindObjectOfType<Dialogue>();
    }

    // Update is called once per frame
    public void OpenDialogue()
    {
        dialogue.setences = speech;
        dialogue.CallDialogue(npcName);
        dialogue.dialogueObj.SetActive(true);
    }
}
