using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject RockPrefab;
    public Vector3 spawnPos;
    Rigidbody rockBody;

    Vector3 newLocation;

    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float rockSpawnTime;
    public float rockSpawnDelay;

    void Start()
    {
        //moves the rock spawning object

    }

    private void Update()
    {
        float distance;
        distance = transform.position.x - newLocation.x;
        float speed = 10f;
        float step = speed * Time.deltaTime;

        if (Time.time >= rockSpawnTime + rockSpawnDelay)
        {
            SpawnFallingRocks();
        }

        if (distance <= 0.1)
        {
            NewWayPoint();
        }

        #region spawnmover



        transform.position = Vector2.MoveTowards(transform.position, newLocation, step);
        distance = transform.position.x - newLocation.x;


        #endregion
    }

    Vector2 NewWayPoint()
    {
        
        int randX = Random.Range(0, 100);
        newLocation = new Vector2(randX, transform.position.y );
        return newLocation;
    }

    void SpawnFallingRocks()
    {
        Instantiate(RockPrefab, transform.position, RockPrefab.transform.rotation);
        rockSpawnDelay = Random.Range(1f, 4f);
        rockSpawnTime = Time.time;
    }

    public void GameOver()
    {

    }

}