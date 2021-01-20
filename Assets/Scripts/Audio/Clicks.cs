using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Clicks : MonoBehaviour
{

    public void click() {
        GetComponent<AudioSource>().pitch = Random.Range(1.5f, 2);
        GetComponent<AudioSource>().Play(0);
    }
}
