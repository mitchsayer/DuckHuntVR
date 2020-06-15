using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBelt : MonoBehaviour
{
    public GameObject duckPrefab;

    public Transform spawnPoint; 
    public Transform destinationPoint;
    public float despawnDistance = 10;

    public float duckSpeed = 1;
    public float spawnTime = 60;
    public float timeSpeed = 1;

    private float timeTillNextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Universe.Instance.GameState == (int)GameStates.Play)
        {
            //Update the time 
            UpdateTime();

            //Its spawn time
            if (timeTillNextSpawn <= 0)
                SpawnDuck();
        }
    }

    private void SpawnDuck()
    {
        //Make new duck
        GameObject duck = Instantiate(duckPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        //Get the script
        DuckScript script = duck.GetComponent<DuckScript>();

        //Apply the variables to the script
        script.destinationPos = destinationPoint;
        script.speed = duckSpeed;
        script.despawnDistance = despawnDistance;

        //Reset Timer
        timeTillNextSpawn = spawnTime;
    }

    private void UpdateTime()
    {
        //If Timer is more than 0
        if (timeTillNextSpawn > 0)
            //Decrease timer by timeSpeed
            timeTillNextSpawn -= timeSpeed;
    }
}
