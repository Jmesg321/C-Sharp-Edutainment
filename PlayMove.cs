using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    public GameObject correctForm;
    BoxCollider2D mCollider;
    SpriteRenderer mSprite;
    Rigidbody2D theRB;
    private bool moving;
    private bool finish;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;




    // Start is called before the first frame update
    void Start()
    {
        resetPosition = this.transform.localPosition;
        mCollider = GetComponent<BoxCollider2D>();
        mSprite = GetComponent<SpriteRenderer>();
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);

            }
        }


    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
            mCollider = GetComponent<BoxCollider2D>();
            mCollider.isTrigger = true;
            theRB = GetComponent<Rigidbody2D>();
            theRB.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
    private void OnMouseUp()
    {

        moving = false;

        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 3.2f &&
           Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 3.2f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            this.transform.localScale = new Vector3(correctForm.transform.localScale.x, correctForm.transform.localScale.y, correctForm.transform.localScale.z);
            mSprite.color = Color.green;
            finish = true;
            mCollider.isTrigger = false;
            AudioManager.instance.PlaySFX(7);
            theRB.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;


        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
            mCollider = GetComponent<BoxCollider2D>();
            mCollider.isTrigger = false;
            AudioManager.instance.PlaySFX(8);
            theRB.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}