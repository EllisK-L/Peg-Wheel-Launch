using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public Scene mainGame;
    void Start() {
    }
    public void startGame() {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        //SceneManager.UnloadScene("Menu");
    }
    public void restartGame() {
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Music"));
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

}
