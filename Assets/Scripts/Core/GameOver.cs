using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;

public class GameOver : MonoBehaviour
{
    public Text highScoreText;
    public Text currentScoreText;
    public GameObject Player;
    public GameObject gameOverCanvas;
    BinaryFormatter formatter = new BinaryFormatter();
    string path;
    float storedScore;
   void Start() {
        path = Application.persistentDataPath + "/" + "highscore" + ".jpeg";
    }
    public void triggerGameOver() {
        transform.GetComponent<Timer>().enabled = false;
        Player.GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);



        if (File.Exists(path)) {
            formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            string stringScore = formatter.Deserialize(stream) as string;
            storedScore = float.Parse(stringScore);
            Debug.Log("Score in File: " + stringScore);
            stream.Close();
        }
        else {
            storedScore = 0;
        }
        float currentScore = transform.GetComponent<playerScore>().getScore();
        if (currentScore > storedScore) {
            Debug.Log("Saving Score");
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, currentScore.ToString());
            stream.Close();
        }


        //enabling score screen
        gameOverCanvas.SetActive(true);
        highScoreText.text = "High Score: " + storedScore.ToString();
        currentScoreText.text = "Your Score: " + currentScore.ToString();

        //disabling the player from clicking to move the ball
        ArrayList wheels = transform.GetComponent<WheelSpawn>().getWheels();
        foreach(GameObject wheel in wheels) {
            int childCount = wheel.transform.childCount;
            for(int i=0; i < childCount; i++) {
                wheel.transform.GetChild(i).GetComponent<StickyPeg>().enabled = false;
            }
        }

    }
}
