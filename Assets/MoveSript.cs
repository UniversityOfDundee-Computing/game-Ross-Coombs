using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSript : MonoBehaviour
{
    public ObstacleSpawnScript spawner;
    public float speed;
    public float despawnPoint = -100;

    // Start is called before the first frame update
    void Start()
    {
        //increase speed from speedMultiplier in spawnScript, so as game progresses game gets faster
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ObstacleSpawnScript>();
        speed = speed * spawner.SpeedMultiplier;
        despawnPoint = -50;
    }

    // Update is called once per frame
    void Update()
    {
        //if moved off the screen then despawn
        if(transform.position.x < despawnPoint)
        {
            Destroy(gameObject);
        }
        //move object left
        transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;
    }
}
