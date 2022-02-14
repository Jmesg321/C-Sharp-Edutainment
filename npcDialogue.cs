using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcDialogue : MonoBehaviour
{
    public Dialogue myWords;


    
    public void TriggerDialogue()
    {
        DialogueManager.DM.StartDialogue(myWords); 
    }
    
   
}
