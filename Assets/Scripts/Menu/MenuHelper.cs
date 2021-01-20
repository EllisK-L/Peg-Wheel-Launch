using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelper : MonoBehaviour
{
    public GameObject wheel;
    void Start()
    {
        Rigidbody2D rb = wheel.GetComponent<Rigidbody2D>();
        rb.angularDrag = 0;
        rb.angularVelocity = 40;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
