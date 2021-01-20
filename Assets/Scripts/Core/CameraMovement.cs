using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    float oldPlayerPos = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Player.transform.position.x > oldPlayerPos) {
            transform.position = new Vector3(Player.transform.position.x, 0, transform.position.z);
            oldPlayerPos = Player.transform.position.x;
        }
    }
}
