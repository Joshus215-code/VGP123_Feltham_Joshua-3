using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(playermovement))]
[RequireComponent(typeof(SpriteRenderer))]
public class playerFire : MonoBehaviour
{

    SpriteRenderer batman;
    playermovement movement;
    

    public Transform spawnPointCrouch;
    public Transform spawnPointStanding;

    public float projectileSpeed;
    public projectile projectilePrefab;




    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<playermovement>();
        batman = GetComponent<SpriteRenderer>();

        if (projectileSpeed <= 0)
        {
            projectileSpeed = 7.0f;
        }




        if (!spawnPointCrouch || !spawnPointStanding || !projectilePrefab)
            Debug.Log("Unity Inspector Not Set");

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            FireProjectile();

        else
        {

        }
    }

    void FireProjectile()
    {

        if (!movement.isCrouching)
        {
            projectile projectileInstance = Instantiate(projectilePrefab, spawnPointStanding.position, spawnPointStanding.rotation);
            Flip(projectileInstance);
        }
        else
        {
            projectile projectileInstance = Instantiate(projectilePrefab, spawnPointCrouch.position, spawnPointCrouch.rotation);
            Flip(projectileInstance);
        }


    }

    void Flip(projectile projectileInstance)
    {
        if (transform.localScale.x <= 0)
        {
            projectileInstance.transform.localScale = new Vector3(-projectileInstance.transform.localScale.x, projectileInstance.transform.localScale.y, projectileInstance.transform.localScale.z);
            projectileInstance.speed = 0 - projectileSpeed;
        }
        else
        {
            projectileInstance.speed = projectileSpeed;
        }
  
    }
}
