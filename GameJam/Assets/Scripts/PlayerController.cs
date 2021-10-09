using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    float horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");


    }
}
