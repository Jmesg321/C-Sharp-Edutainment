using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowName : MonoBehaviour
{
    public Text Username;

    // Start is called before the first frame update
    void Start()
    {
        Username.text = (PlayerPrefs.GetString("user_name"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
