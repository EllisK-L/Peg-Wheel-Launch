using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        //gameObject.GetComponent<Rigidbody2D>().AddForce(test.transform.up * .2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
            // Debug.DrawRay(transform.position, transform.up * 100, Color.green, 1);
        }
    }
}
