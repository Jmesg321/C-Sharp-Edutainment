using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;

        rb.bodyType = RigidbodyType2D.Kinematic;

    }

    private void OnMouseUp()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }


}

