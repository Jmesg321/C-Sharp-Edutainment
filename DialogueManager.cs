using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager DM;
    Queue<string> sentences;
    public Text nameText, dialogueText;
    public Animator boxAnim;
    public float characterDelay;
    public GameObject NPCTrigger;


    // Start is called before the first frame update

    private void Awake()
    {
        DM = this;
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue di)
    {
        boxAnim.SetBool("IsIn", true);
        nameText.text = di.name;
        sentences.Clear();
        foreach (string line in di.npcLines)
        {
            sentences.Enqueue(line);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sen = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(CharByChar(sen));
        //dialogueText.text = sen;
    }
    public void EndDialogue()
    {
        boxAnim.SetBool("IsIn", false);
        PlayerController.instance.stopInput = false;
        print("dialogueText ended");
        NPCTrigger.gameObject.SetActive(false);
    }

    public IEnumerator CharByChar(string sentenceToType)
    {
        dialogueText.text = "";
        foreach(char c in sentenceToType.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(characterDelay);
        }
        
    }
    

}
