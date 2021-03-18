using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(playermovement))]

public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D rb;
    playermovement pm;


    public float bounceForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<playermovement>();

        if(bounceForce <= 0)
        {
            bounceForce = 30.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "EnemyProjectile" || collision.gameObject.tag == "enemy")
        {
            GameManager.instance.lives--;
        }
        
        if(collision.gameObject.tag == "enemy")
        {
            if (!pm.isGrounded)
            {
                collision.gameObject.GetComponentInParent<enemyMovement>().IsDead();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounceForce);
            }
        }
    }
    

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
