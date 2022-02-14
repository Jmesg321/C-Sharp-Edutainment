using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropMinigame : MonoBehaviour
{
    public GameObject floatie, intie, booly, floatieBlack, intieBlack, boolyBlack;
    public string levelToLoad;


    Vector2 floatieInitialPos, intieInitialPos, boolyInitialPos;

    bool floatieCorrect, intieCorrect, boolyCorrect = false;

  

    // Start is called before the first frame update
    void Start()
    {
        floatieInitialPos = floatie.transform.position;
        intieInitialPos = intie.transform.position;
        boolyInitialPos = booly.transform.position;
    }

    
    
    public void DragIntie()
    {
        intie.transform.position = Input.mousePosition;
    }

    public void DragFloatie()
    {
        floatie.transform.position = Input.mousePosition;
    }

    public void DragBooly()
    {
        booly.transform.position = Input.mousePosition;
    }


    public void DropIntie()
    {
        float Distance = Vector3.Distance(intie.transform.position, intieBlack.transform.position);
        if (Distance < 50)
        {
            intie.transform.position = intieBlack.transform.position;
            intieCorrect = true;
        }
        else
        {
            intie.transform.position = intieInitialPos;
        }
    }

    public void DropBooly()
    {
        float Distance = Vector3.Distance(booly.transform.position, boolyBlack.transform.position);
        if (Distance < 50)
        {
            booly.transform.position = boolyBlack.transform.position;
            boolyCorrect = true;
        }
        else
        {
            booly.transform.position = boolyInitialPos;
        }
    }

    public void DropFloatie()
    {
        float Distance = Vector3.Distance(floatie.transform.position, floatieBlack.transform.position);
        if (Distance < 50)
        {
            floatie.transform.position = floatieBlack.transform.position;
            floatieCorrect = true;
        }
        else
        {
            floatie.transform.position = floatieInitialPos;
        }
    }
    void Update()
    {
        if (floatieCorrect && intieCorrect && boolyCorrect)
        {
            Debug.Log("win");
            SceneManager.LoadScene(levelToLoad);


        }
    }

}
