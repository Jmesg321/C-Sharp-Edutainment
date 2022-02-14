using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathGameManager : MonoBehaviour
{
    public Problem[] problems;
    public int curProblem;
    public float timePerProblem;
    public float remainingTime;
    public GameObject player;
    public GameObject pickupEffect;
    public GameObject Box1, Box2, Box3;
    public GameObject Next, Retry, Quit;
    
    
    

    public static MathGameManager instance;
    void Awake()
    {
        instance = this;
    }

    void Win()
    {
        AudioManager.instance.PlayLevelVictory();
        MathUI.instance.SetEndText(true);
        Next.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
       
        remainingTime = 1000f;
        

    }

    void Lose()
    {
        
        MathUI.instance.SetEndText(false);
        Retry.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        
        

    }

    void SetProblem(int problem)
    {
        curProblem = problem;
        remainingTime = timePerProblem;
        MathUI.instance.SetProblemText(problems[curProblem]);
    }

    void CorrectAnswer()
    {

        Instantiate(pickupEffect, Box1.transform.position, Box1.transform.rotation);
        Instantiate(pickupEffect, Box2.transform.position, Box2.transform.rotation);
        Instantiate(pickupEffect, Box3.transform.position, Box3.transform.rotation);
        
        
       

        AudioManager.instance.PlaySFX(7);

        if (problems.Length - 1 == curProblem)
            Win();
        else
            SetProblem(curProblem + 1);
    }

    void IncorrectAnswer()
    {
        PlayerHealthController.instance.DealDamage();
    }

    public void OnPlayerEnterBox(int Box)
    {
        if (Box == problems[curProblem].correctbox)
            CorrectAnswer();
        else
            IncorrectAnswer();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0.0f)
        {
            Lose();
        }
    }
     void Start()
    {
        SetProblem(0);
    }
}
