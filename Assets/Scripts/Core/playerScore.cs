using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class playerScore : MonoBehaviour
{
    public GameObject Player;
    public Text scoreText;
    float oldPlayerPos = 0;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x > oldPlayerPos) {
            score = math.trunc(Player.transform.position.x) ;
            oldPlayerPos = Player.transform.position.x; 
        }
        scoreText.text = "Score: " + score.ToString();
    }
    public float getScore() {
        return score;
    }
}
