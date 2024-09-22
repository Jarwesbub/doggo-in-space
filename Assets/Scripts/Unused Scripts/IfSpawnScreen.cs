using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfSpawnScreen : MonoBehaviour
{


    public float SpawnScreen = 0f;




    void OnBecameVisible()                          //OnBecameVisible ja SpawnScreen voi poistaa jos ei toimi!!!
    {
        if (SpawnScreen == 0f)
        {
            SpawnScreen = 1f;
        }

    }

    void OnBecameInvisible()
    {
        if (SpawnScreen == 0f)
        {
            SpawnScreen = 2f;
        }

    }
    //*/


    // Start is called before the first frame update
    void Start()
    {
        if (SpawnScreen == 1f)
        {
            Destroy(gameObject);
        }
        else
        {
            SpawnScreen = 2f;
        }
    
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
