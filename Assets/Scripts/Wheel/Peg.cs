using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    public GameObject lockedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (lockedObject != null) {
                lockedObject.transform.SetParent(null);
                lockedObject.transform.GetComponent<Rigidbody2D>().simulated = true;
                lockedObject.transform.GetComponent<Rigidbody2D>().velocity = lockedObject.transform.up * 20;
                //lockedObject.transform.GetComponent<Rigidbody2D>().AddForce(transform.up * .2f);

                transform.GetComponent<BoxCollider2D>().enabled = false;
                lockedObject = null;
                Debug.Log("Unlocked");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        collision.transform.GetComponent<Rigidbody2D>().simulated = false;
        collision.transform.SetParent(transform.parent.transform);
        collision.transform.rotation = transform.rotation;
        lockedObject = collision.gameObject;

        Vector3 ballRelative = transform.InverseTransformPoint(collision.transform.position);
        if(ballRelative.x > 0) {
            transform.parent.GetComponent<Rigidbody2D>().angularVelocity = 200;
        }
        else {
            transform.parent.GetComponent<Rigidbody2D>().angularVelocity = -200;
        }
    }

}
