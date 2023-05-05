using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public System.Random randomiser = new System.Random();
    private int random = 0;

    public GameObject[] obstacles = new GameObject[4];
    public GameObject[] powerups = new GameObject[4];

    public float ObstacleSpawnRate = 2.5f;
    public float PowerupSpawnRate = 10;
    private float ObstacleTimer = 0;
    private float PowerupTimer = 0;
    public float heightOffset = 5;
    public float SpeedMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        //spawn first obstacle (always a wall)
        spawnObstacle(obstacles[random]);
    }

    // Update is called once per frame
    void Update()
    {
        if (ObstacleTimer < ObstacleSpawnRate)
        {
            //if too soon to spawn obstacle then increase timer
            ObstacleTimer = ObstacleTimer + Time.deltaTime;
        } else
        {
            //spawn random obstacle
            random = randomiser.Next(0, 4);
            spawnObstacle(obstacles[random]);
            //reset timer
            ObstacleTimer = 0;

            //increase speed & frequency
            SpeedMultiplier = SpeedMultiplier * 1.005f;
            ObstacleSpawnRate = ObstacleSpawnRate * 0.995f;
            PowerupSpawnRate = PowerupSpawnRate * 0.995f;

            //first time a breakable wall is spawned, show missile tutorial
            if(random == 3 && LogicScript.instance.missileTutorial == false)
            {
                LogicScript.instance.missileTutorialOn();
            }
        }

        if (PowerupTimer < PowerupSpawnRate)
        {
            //if too soon to spawn cannonball then increase timer
            PowerupTimer = PowerupTimer + Time.deltaTime;
        }
        else
        {
            //get random powerup, if lives is 1 then allow spawning of a heart
            if (LogicScript.instance.lives <= 1)
            {
                random = randomiser.Next(0, 4);
            }
            else
            {
                random = randomiser.Next(1, 4);
            }
            //spawn random powerup
            spawnObstacle(powerups[random]);
            //reset timer
            PowerupTimer = 0;
        }

    }

    private void spawnObstacle(GameObject obstacle)
    {
        //spawn at random height
        float highest = transform.position.y + heightOffset;
        float lowest = transform.position.y - heightOffset;
        Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(lowest, highest), 0), transform.rotation);
    }
}
