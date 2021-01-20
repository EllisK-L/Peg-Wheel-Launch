using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text gameTimer;
    private float timeLeft;
    public float startTime;
    float originalTime;
    // Start is called before the first frame update
    void Start()
    {
        originalTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = startTime - (Time.time - originalTime);
        if (timeLeft > 5) {
            gameTimer.color = Color.green;
        }
        if (timeLeft < 5 && timeLeft > 2) {
            gameTimer.color = Color.yellow;
        }
        if (timeLeft < 2 && timeLeft > 1) {
            gameTimer.color = Color.red;
        }
        if (timeLeft < 1) {
            if((math.trunc(timeLeft*10)) % 2 == 0) {
                gameTimer.color = Color.red;
            }
            else {
                gameTimer.color = Color.yellow;
            }
        }
        gameTimer.text = (math.trunc(timeLeft * 100)/100).ToString();
        if (timeLeft <= 0) {
            gameTimer.text = "0.00";
            gameTimer.color = Color.red;
            gameTimer.fontStyle = FontStyle.Bold;
            transform.GetComponent<GameOver>().triggerGameOver();
        }
    }
    public void addSubTime(float amount = 2.2f) {
        startTime += amount;
    }
}
