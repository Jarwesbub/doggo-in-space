using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.Play("laika_idle");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
