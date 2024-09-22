using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [SerializeField]
    Transform rotationCenter;

    //How fast object rotate

    public float angularSpeed = 0.17f;

    //How far object is from the center
    [SerializeField]
    public float rotationRadius = 2f;

    public float posX, posY, angle = 0f;

    bool isClone;


    void Start()
    {
        rotationRadius = Random.Range(15.0f, 29.0f);

        //2.0f -> 7.5f = No spawning on screen!
        angle = Random.Range(2.0f, 7.5f);

        isClone = gameObject.name.Contains("(Clone)");

    }


    //Was "Update" at first but Fixed made better framework
    void FixedUpdate()
    {
        if (isClone)
        {
            posX = (rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius);
            posY = (rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius);
            transform.position = new Vector2(posX, posY);
            angle = angle + Time.deltaTime * angularSpeed;

            if (angle >= 360f)
            {
                angle = 0f;
            }
        }

    }

    // original
    // posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
    // posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
    // transform.position = new Vector2(posX, posY);
    // angle = angle + Time.deltaTime* angularSpeed;

}
