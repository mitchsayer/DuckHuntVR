using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBelt : MonoBehaviour
{
    public GameObject duckPrefab;

    public Transform spawnPoint; 
    public Transform destinationPoint;
    public float despawnDistance = 10;
    public float pathChangeDistance = 10;

    public float duckSpeed = 1;
    public float spawnTime = 60;

    public float speedIncrease = 0;
    public float speedIncreaseTimeInterval = Mathf.Infinity;

    public List<Vector3> pathPoints;

    public List<DuckScript> ducks;

    private float timeSpeed = 1;

    private float timeTillNextSpeedIncrease = 0;

    private float timeTillNextSpawn = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize Lists
        ducks = new List<DuckScript>();
        //pathPoints = new List<Vector3>();
        pathPoints.Add(spawnPoint.position);
        pathPoints.Add(destinationPoint.position);
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

            //Speed, I am speed
            if (timeTillNextSpeedIncrease <= 0)
                IncreaseSpeed(speedIncrease);

             
        }

        int i = 0;

        //Go through all the ducks
        foreach (DuckScript duck in ducks)
        {

            //If a duck needs a new path point 
            if (duck.NeedsPathPoint())
            {
                //Change the path
                duck.pathIter += 1;
                if (duck.pathIter < pathPoints.Count)
                    duck.tarPos = pathPoints[duck.pathIter];
            }

            //If it is time...
            if (duck.Despawn())
            {
                //..then the end is nigh
                Destroy(duck.gameObject);
                ducks.RemoveAt(i);
            }

            i++;
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
        script.pathIter = 0;
        script.tarPos = pathPoints[0];
        script.speed = duckSpeed;
        script.destinationPos = destinationPoint;
        script.despawnDistance = despawnDistance;
        script.pathChangeDistance = pathChangeDistance;

        //Add to list
        if (script)
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
