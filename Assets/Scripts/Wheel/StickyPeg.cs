using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPeg : MonoBehaviour
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
        thisPeg.collisionEnter(col.transform.gameObject);
    }
}
