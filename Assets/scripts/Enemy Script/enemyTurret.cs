using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class enemyTurret : MonoBehaviour
{

    public Transform projectileSpawnpoint;
    public projectile projectilePrefab;

    public bool facingRight = true;

    public float attackRange;
    private float distanceToTarget;
  

    public float projectileForce;

    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;

    private playermovement player;
    private Transform playerPos;
   

    public GameObject turret;



    public int health;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        anim = GetComponent<Animator>();

        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(playerPos.position , turret.gameObject.transform.position) < attackRange)
        {
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                anim.SetBool("Fire", true);
                timeSinceLastFire = Time.time;
            }
        }


       

        if (player.transform.position.x < gameObject.transform.position.x && facingRight)
            Flip();

        if (player.transform.position.x > gameObject.transform.position.x && !facingRight)
            Flip();




    }

    void Flip()
    {
        
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

    public void Fire()
    {
        if (projectileSpawnpoint)
        {
            projectile projectileInstance = Instantiate(projectilePrefab, projectileSpawnpoint.position, projectileSpawnpoint.rotation);
            flip(projectileInstance);
        }
        else
        {
            projectile projectileInstance = Instantiate(projectilePrefab, projectileSpawnpoint.position, projectileSpawnpoint.rotation);
            flip(projectileInstance);
        }


    }



    void flip(projectile projectileInstance)
    {
        if (transform.localScale.x <= 0)
        {
            projectileInstance.transform.localScale = new Vector3(-projectileInstance.transform.localScale.x, projectileInstance.transform.localScale.y, projectileInstance.transform.localScale.z);
            projectileInstance.speed = 0 - projectileForce;
        }
        else
        {
            projectileInstance.speed = projectileForce;
        }
  
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Playerprojectile")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

 

    
}
