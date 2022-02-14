using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathEnemies : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;
    public GameObject explosion;




    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(10f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            

            PlayerHealthController.instance.DealDamage();
        }
    }

    void MoveEnemy()
        
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);

        }
        else
            rb.velocity = Vector3.zero;
    }



}
