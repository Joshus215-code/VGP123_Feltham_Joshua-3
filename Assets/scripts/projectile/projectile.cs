using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class projectile : MonoBehaviour
{

    public float speed;
    public float lifetime;

    public Transform projectilePrefab;


 


    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
            
        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);


               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
           
            Destroy(gameObject);
        }
       

        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Playerprojectile")
        {
            Destroy(gameObject);
        }

         if (collision.gameObject.tag == "Turret")
        {
            Destroy(gameObject);
        }

        else
        {
            
        }
        
    }
}
