using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachable : MonoBehaviour{

    public GameObject attachedObject = null;
    
    public bool isAttached() {
        if(attachedObject == null) {
            return false;
        }
        else {
            return true;
        }
    }
    public GameObject getAttached() {
        return attachedObject;
    }
    public void setAttached(GameObject obj) {
        attachedObject = obj;
    }

}
