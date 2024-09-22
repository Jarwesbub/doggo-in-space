using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    //Level updates when objects make full circle. More objects will be spawned  with this command
    int level;

    //Calculates how many object get spawned
    int maxJunk;
    int junkCount = 0;

    public GameObject hpbone1;
    public GameObject hpmax;
    public GameObject deadguy;
    public GameObject satellite;
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;

    void Start()
    {
        JunkLevelUp();
    }

    public void JunkLevelUp() // Adds +1 level
    {
        level += 1;
        SetMaxJunk();
    }

    void SetMaxJunk()
    {
        int[] junkArr = { 18, 20, 25, 30, 40, 50, 65, 80, 95, 115, 135, 155, 180, 205, 230, 255, 285, 315, 345, 375, 405 };
        int maxLevel = 20;
        if (level > maxLevel)
        {
            level = maxLevel;
        }

        maxJunk = junkArr[level];

    }

    void Update()
    {
        //Secret level button - DELETE THIS LATER
        if (Input.GetKeyDown("c"))
        {
            JunkLevelUp();
        }

        if(junkCount < maxJunk)
        {
            int randomValue = Random.Range(0, 101);
            SpawnJunkByValue(randomValue);
            junkCount++;
        }

    }

    void SpawnJunkByValue(int value)
    {
        //HP Bones spawner level 1 (1-6)                                                            
        if ((value >= 0) && (value <= 7))
        {
            Instantiate(hpbone1);
            gameObject.layer = LayerMask.NameToLayer("HP");
        }

        //HP Max spawner level 1 (7)
        else if ((value >= 6) && (value <= 8))
        {
            Instantiate(hpmax);
            gameObject.layer = LayerMask.NameToLayer("HP Max");
        }

        //Deadguy spawner level 1 (8-9)
        else if ((value >= 7) && (value <= 10))
        {
            Instantiate(deadguy);
            gameObject.layer = LayerMask.NameToLayer("Deadman");
        }


        //Satellite spawner level 1 (10-20)
        else if ((value >= 9) && (value <= 21))
        {
            Instantiate(satellite);
            gameObject.layer = LayerMask.NameToLayer("Satellite");
        }


        //Asteroid1 spawner level 1 (20-50)
        else if ((value >= 19) && (value <= 51))
        {
            Instantiate(asteroid1);
            gameObject.layer = LayerMask.NameToLayer("Asteroids");
        }
        //Asteroid2 spawner level 1 (50-75)
        if ((value >= 49) && (value <= 76))
        {
            Instantiate(asteroid2);
            gameObject.layer = LayerMask.NameToLayer("Asteroids");
        }


        //Asteroid3 spawner level 1 (75-100)
        else if ((value >= 74) && (value <= 101))
        {
            Instantiate(asteroid3);
            gameObject.layer = LayerMask.NameToLayer("Asteroids");
        }
    }
}
