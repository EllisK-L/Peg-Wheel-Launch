using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    float oldPos = 0;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(.001f * Player.transform.position.x , 0);
        oldPos = Player.transform.position.x;

        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }
}
