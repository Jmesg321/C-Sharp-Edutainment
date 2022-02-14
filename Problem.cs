using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class Problem 
{
   
    public enum MathsOperation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

   
    public float firstNumber;
    public float secondNumber;
    public MathsOperation operation;
    public float[] answers;
    

    [Range(0, 3)]
    public int correctbox;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
