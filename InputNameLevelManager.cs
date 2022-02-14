using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputNameLevelManager : MonoBehaviour
{
    public GameObject Yes;
    public string NameLevel;


    void Update()
    {

    }
    public void GameStart()
    {
        SceneManager.LoadScene(NameLevel);
        
    }

}

