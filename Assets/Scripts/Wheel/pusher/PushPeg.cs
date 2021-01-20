using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPeg : MonoBehaviour
{
    PegBase thisPeg;

    void Start(){
        thisPeg = new PegBase(transform.gameObject, GameObject.Find("GameHelper"));
    }
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if(thisPeg.getLocked() != null){
                thisPeg.unParentObj();
                thisPeg.shootObj();
                thisPeg.unlockObj();
            }

        }
    }

    public void OnCollisionEnter2D(Collision2D col){
        GameObject collision = col.transform.gameObject;
        thisPeg.collisionEnter(collision);
        collision.transform.GetComponent<Rigidbody2D>().simulated = true;
        collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        collision.GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
        
    }
}
