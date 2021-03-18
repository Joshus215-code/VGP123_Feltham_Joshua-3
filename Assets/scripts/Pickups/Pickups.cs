using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    public enum CollectibleType
    {
        POWERUP,
        BOMB,
        COLLECTIBLE,
        LIVES
    }


    /*   

    public GameObject[] myObjects;
    public int collectNum;
    Vector2 spawnlocation;

    private void Start()
    {
        
    
    while (collectNum < 5)
    { int randomIndex = Random.Range(0, 100);
        spawnlocation = new Vector2(1.85f + collectNum * 1.4f, -3.98f);
            if  (randomIndex < 25)

        {
              Instantiate(myObjects[0], spawnlocation, Quaternion.identity) ;
        }
            else if (randomIndex < 50)

        {
             Instantiate(myObjects[1], spawnlocation, Quaternion.identity);
        }
           else if  (randomIndex < 75)

        {
              Instantiate(myObjects[2], spawnlocation, Quaternion.identity) ;
        }
             else
        {
              Instantiate(myObjects[3], spawnlocation, Quaternion.identity) ;
        }
            collectNum++;
       }
    }

    */

    public CollectibleType currentCollectible;

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.POWERUP:
                    Debug.Log("POWERUP");
                    collision.GetComponent<playermovement>
                        ().StartJumpForceChange();
                    Destroy(gameObject);
                    break;

                case CollectibleType.COLLECTIBLE:
                    Debug.Log("Collectible");
                    GameManager.instance.score++;
                    Destroy(gameObject);
                    break;

                case CollectibleType.LIVES:
                    Debug.Log("Lives");
                    GameManager.instance.lives++;                    
                    Destroy(gameObject);
                    break;
            }
        }
    }

}
