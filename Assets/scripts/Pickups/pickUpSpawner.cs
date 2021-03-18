using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] myObjects;
    public int collectNum;
    Vector2 spawnlocation;

    private void Start()
    {


        while (collectNum < 5)
        {
            int randomIndex = Random.Range(0, 100);
            spawnlocation = new Vector2(1.85f + collectNum * 1.4f, -3.98f);
            if (randomIndex < 20)

            {
                Instantiate(myObjects[0], spawnlocation, Quaternion.identity);
            }
            else if (randomIndex < 40)

            {
                Instantiate(myObjects[1], spawnlocation, Quaternion.identity);
            }
            else if (randomIndex < 60)

            {
                Instantiate(myObjects[2], spawnlocation, Quaternion.identity);
            }
            else if (randomIndex < 80)
            {
                Instantiate(myObjects[3], spawnlocation, Quaternion.identity);
            }
            else 
            {
                Instantiate(myObjects[4], spawnlocation, Quaternion.identity);
            }
            collectNum++;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
