using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public Text obj_text;
    public Text QuestionText;
    public InputField display;
    public GameObject Yes, No, Confirm, Clear,InputBox;
   
   






    // Start is called before the first frame update
    private void Awake()
    {
        Yes.gameObject.SetActive(false);
        No.gameObject.SetActive(false);

    }

    public void Create()
    {
        obj_text.text = display.text;
        QuestionText.text = "Your Name is?";
        
        PlayerPrefs.SetString("user_name", obj_text.text);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("user_name"));
       
        Yes.gameObject.SetActive(true);
        No.gameObject.SetActive(true);
        Confirm.gameObject.SetActive(false);
        Clear.gameObject.SetActive(false);
        InputBox.gameObject.SetActive(false);
    }

    public void Reset()
    {
        
        PlayerPrefs.DeleteKey("user_name");
        obj_text.text = display.text = "";
        QuestionText.text = "What is your Name?";

        Yes.gameObject.SetActive(false);
        No.gameObject.SetActive(false);
        Confirm.gameObject.SetActive(true);
        Clear.gameObject.SetActive(true);
        InputBox.gameObject.SetActive(true);
        
        Debug.Log(PlayerPrefs.GetString("user_name"));
    }
}
