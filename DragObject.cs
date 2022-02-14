using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    Rigidbody2D rb;

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;

    }

    private void OnMouseDrag()
    {
        transform.position = difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
