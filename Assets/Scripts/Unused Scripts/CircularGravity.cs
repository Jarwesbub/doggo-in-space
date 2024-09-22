using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularGravity : MonoBehaviour
{

    public float massofEarth;
    public Transform centerofEarth;
    public float G;

    float massofPlayer;
    float distance;
    float forceValue;

    Vector3 forceDirection;
    Rigidbody2D rBody;

    //Moving right
    [SerializeField]
    private float MoveSpeed = 1f;

    //FlyDog script
    public float velocity = 1;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        massofPlayer = rBody.mass;
        distance = Vector3.Distance(centerofEarth.position, transform.position);
        forceValue = G * (massofEarth * massofPlayer) / (distance * distance);
    
    
    }

    // Update is called once per frame
    void Update()
    {
        forceDirection = (centerofEarth.position - transform.position).normalized;
        rBody.AddForce(forceValue * forceDirection); //We need value and direction of the force

        if (Input.GetMouseButton(0))
        {

            //Jump script (FlyDog script)
            //rBody.velocity = Vector2.up * velocity;

            rBody.velocity = Vector3.up * velocity;

        }



        //testing movement checking right
        if (Input.GetKey("right"))
        {
            rBody.velocity = new Vector3(MoveSpeed, rBody.velocity.y);


        }



    }
}
