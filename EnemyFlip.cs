using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    public float moveSpeed = 1f;
    Rigidbody2D myRB;
    BoxCollider2D myBoxCol;
   
 

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myBoxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingLeft())
        {
            myRB.velocity = new Vector2(-moveSpeed, 0f);
        }
        else
        {
            myRB.velocity = new Vector2(moveSpeed, 0f);
        }
        
    }
    private bool isFacingLeft()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector2((Mathf.Sign(myRB.velocity.x)), transform.localScale.y);
    }

 }

