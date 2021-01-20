using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushHead : MonoBehaviour
{
    public GameObject pusher;
    void OnCollisionEnter2D(Collision2D col){
        if(col.transform.tag == "Player"){
            pusher.GetComponent<Pusher>().hitPlayer(col.transform.gameObject);
            Debug.Log("COLLIEDED");
        }
    }
}
