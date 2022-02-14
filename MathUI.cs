using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathUI : MonoBehaviour
{
    public Text problemText;
    public Text[] answersTexts;

    public Image remainingTimeDial;
    private float remainingTimeDialRate;

    public Text endText;

    public static MathUI instance;
    private void Awake()
    {
        instance = this;
    }




    // Start is called before the first frame update
    void Start()
    {
        remainingTimeDialRate = 1.0f / MathGameManager.instance.timePerProblem;
    }

    // Update is called once per frame
    void Update()
    {
        remainingTimeDial.fillAmount = remainingTimeDialRate * MathGameManager.instance.remainingTime;
    }

    public void SetProblemText(Problem problem)
    {
        string operatorText = "";
        switch (problem.operation)
        {
            case Problem.MathsOperation.Addition: operatorText = " + "; break;
            case Problem.MathsOperation.Subtraction: operatorText = " - "; break;
            case Problem.MathsOperation.Multiplication: operatorText = " x "; break;
            case Problem.MathsOperation.Division: operatorText = " ÷ "; break;
        }
        
        problemText.text = problem.firstNumber + operatorText + problem.secondNumber;

        for (int index = 0; index < answersTexts.Length; ++index)
        {
            answersTexts[index].text = problem.answers[index].ToString();
        }
    }
        public void SetEndText(bool win)
        {
        endText.gameObject.SetActive(true);
        if (win)
        {
            endText.text = "You Win!";
            endText.color = Color.green;
        }
        else
        {
            endText.text = "Game Over!";
            endText.color = Color.red;
        
        
        }

    }
}
