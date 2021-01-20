using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PegBase
{
    GameObject thisObj;
    float collisionExitTime;
    GameObject lockedObject;
    public GameObject gameHelper;

    //in millis
    float collisionDetectTime = 100;
    public PegBase(GameObject thisObj, GameObject gameHelper){
        this.gameHelper = gameHelper;
        this.thisObj = thisObj;
        collisionExitTime = Time.time * 1000;
    }

    public GameObject getLocked(){
        return lockedObject;
    }

    public void unParentObj(){
        if(lockedObject == null){
            return;
        }
        lockedObject.transform.SetParent(null);
        lockedObject.transform.GetComponent<Rigidbody2D>().simulated = true;
    }

    public void shootObj(float vel = 20){
        if(lockedObject == null){
            return;
        }
        lockedObject.transform.GetComponent<Rigidbody2D>().velocity = lockedObject.transform.up * vel;
        collisionExitTime = Time.time * 1000;
    }
    public void unlockObj(){
        lockedObject = null;
    }


    public void collisionEnter(GameObject collision){
        //checking if an object has just existed
        float newTime = Time.time * 1000;
        Debug.Log(newTime - collisionExitTime);
        if(newTime - collisionExitTime > collisionDetectTime){
            gameHelper.GetComponent<Timer>().addSubTime();
            collision.transform.GetComponent<Clicks>().click();

            collision.transform.GetComponent<Rigidbody2D>().simulated = false;
            collision.transform.SetParent(thisObj.transform.parent.transform);
            collision.transform.rotation = thisObj.transform.rotation;
            lockedObject = collision.gameObject;


            Vector3 ballRelative = thisObj.transform.InverseTransformPoint(collision.transform.position);
            if(ballRelative.x > 0) {
                thisObj.transform.parent.GetComponent<Rigidbody2D>().angularVelocity = 100;
            }
            else {
                thisObj.transform.parent.GetComponent<Rigidbody2D>().angularVelocity = -100;
            }

        }



    }
    
}