using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stock;
    public GameObject head;
    Vector3 currentScale;
    float scaleChange = 2f;
    bool stopLoop = false;
    void Start()
    {
        // stock.transform.localScale = new Vector3(10,10,10);
    }

    // Update is called once per frame
    void Update()
    {
        currentScale = stock.transform.localScale;
        // Debug.Log(currentScale);
        if(stopLoop == false){
            stock.transform.localScale = new Vector3(currentScale.x, currentScale.y + (scaleChange * Time.deltaTime), currentScale.z);
            stock.transform.Translate(0,(scaleChange/.68f) * Time.deltaTime,0);
            head.transform.Translate(0,(scaleChange/.342f) * Time.deltaTime,0);
        }
    }
    public void hitPlayer(GameObject player){
        player.transform.parent = transform;
        stopLoop = true;
        player.GetComponent<Rigidbody2D>().useFullKinematicContacts = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        player.GetComponent<Rigidbody2D>().simulated = false;

    }
}
