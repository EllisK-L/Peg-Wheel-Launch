using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelSpawn : MonoBehaviour
{
    public GameObject Player;
    public GameObject Wheel;
    // in millis
    public float spawnDist;
    public int spawnStart;
    private float lastMilestone = 0;
    private ArrayList wheelArr = new ArrayList();

    void Start(){
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleScene"));
        wheelArr.Add(Instantiate(Wheel, new Vector3(lastMilestone + (1 * spawnDist), -8), Quaternion.identity));
        //making the first couple wheels
        for(int i = 2; i < spawnStart; i++){
            wheelArr.Add(Instantiate(Wheel, new Vector3(lastMilestone + (i * spawnDist), Random.Range(-20,20), 0), Quaternion.Euler(0,0,Random.Range(0,90))));
        }
    }
    void Update()
    {
        //checking if the player has reached the next milestone
        if(Player.transform.position.x - lastMilestone >= spawnDist){
            Debug.Log("Next Milestone Reached, spawning new wheel");
            wheelArr.Add(Instantiate(Wheel, new Vector3(lastMilestone + (spawnStart * spawnDist), Random.Range(-20,20), 0), Quaternion.Euler(0,0,Random.Range(0,90))));

            //checking if a wheel can be deleted
            GameObject toDestroy = null;
            foreach(GameObject wheel in wheelArr){
                if(Player.transform.position.x - wheel.transform.position.x > 4 * spawnDist){
                    toDestroy = wheel;
                }
            }
            //Deleting the wheel if one is far enough away to be deleted
            wheelArr.Remove(toDestroy);
            Destroy(toDestroy);

            lastMilestone += spawnDist;
        }
    }

    bool canSpawnHere(Transform hit){
        return true;
    }
    public ArrayList getWheels() {
        return wheelArr;
    }
}
