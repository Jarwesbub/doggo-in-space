using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotRandom : MonoBehaviour
{

    float randomNumb = Random.Range(0.00f, 8.00f);

    void Update()
    {
        transform.Rotate(0, 0, randomNumb * Time.deltaTime);
    }
}
