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

    public float speedIncrease = 0;
    public float speedIncreaseTimeInterval = Mathf.Infinity;

    private float timeSpeed = 1;

    private float timeTillNextSpeedIncrease = 0;

    private float timeTillNextSpawn = 0.0f;

    private List<DuckScript> ducks;

    // Start is called before the first frame update
    void Start()
    {
        ducks = new List<DuckScript>();
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

            if (timeTillNextSpeedIncrease <= 0)
                IncreaseSpeed(speedIncrease);
        }
    }

    private void SpawnDuck()
    {
        //Make new duck
        GameObject duck = Instantiate(duckPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        //Get the script
        DuckScript script = duck.GetComponent<DuckScript>();

        //Make the spawned duck a child of the duck manager
        duck.transform.parent = gameObject.transform;

        //Apply the variables to the script
        script.destinationPos = destinationPoint;
        script.speed = duckSpeed;
        script.despawnDistance = despawnDistance;

        //Add to list
        if(script)
        ducks.Add(script);

        //Reset Timer
        timeTillNextSpawn = spawnTime;
    }

    private void UpdateTime()
    {
        //If Timer is more than 0
        if (timeTillNextSpawn > 0)
            //Decrease timer by timeSpeed
            timeTillNextSpawn -= timeSpeed;

        //If Timer is more than 0
        if (timeTillNextSpeedIncrease > 0)
            //Decrease timer by timeSpeed
            timeTillNextSpeedIncrease -= timeSpeed;
    }

    public void IncreaseSpeed(float a_multiplier)
    {
        //Imcrease speed
        duckSpeed *= 1 + a_multiplier;

        //Increase all ducks speed
        foreach(DuckScript duck in ducks) 
            duck.speed = duckSpeed; 

        //Reset Timer
        timeTillNextSpeedIncrease = speedIncreaseTimeInterval;
    }
}
