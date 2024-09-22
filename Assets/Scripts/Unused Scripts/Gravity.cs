using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public GameObject Earth;
    private Rigidbody2D rb;
    [Range(0, 5)]
    public float factor = 1;
    public ForceMode2D mode;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 g = (Earth.transform.position - transform.position) * factor;
        rb.AddForce(g, mode);
    }

}
