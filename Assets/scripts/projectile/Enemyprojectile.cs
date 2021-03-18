using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyprojectile : MonoBehaviour
{
    public float speed;
    public float lifetime;

    public Transform EprojectilePrefab;





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

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playermovement>().IsDead();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "enemy")
        {
            if (collision.gameObject.GetComponent<enemyTurret>())
            {
                Destroy(gameObject);
            }

            else
            {
                collision.gameObject.GetComponent<enemyMovement>().IsDead();
                Destroy(gameObject);
            }
        }
    }
}
