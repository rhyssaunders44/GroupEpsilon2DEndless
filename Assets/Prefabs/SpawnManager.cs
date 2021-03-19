using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject RockPrefab;
    public Vector3 spawnPos;
    Rigidbody rockBody;

    public int rockCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float rockSpawnTime;
    public float rockSpawnDelay;
    public bool alive;

    void Start()
    {
        //moves the rock spawning object
        #region spawnmover

        float distance;
        float speed = 10f;
        float step = speed * Time.deltaTime;
        InvokeRepeating("RockEnemies", 1, 5);
        transform.position = Vector2.MoveTowards(transform.position, NewWayPoint(), step);
        distance = transform.position.x - NewWayPoint().x;

        if(distance <= 0.2)
        {
            NewWayPoint();
        }
        #endregion

        alive = PlayerScript.alive;
        if (Time.time >= rockSpawnTime + rockSpawnDelay)
        {
            SpawnFallingRocks();
        }

        if (alive == false)
        {
            EndGame();
        }

    }

    Vector2 NewWayPoint()
    {
        Vector2 newLocation;
        int randX = Random.Range(5, 15);
        newLocation = new Vector2(randX, 0 );
        return newLocation;
    }

    void RockEnemies()
    {
        Instantiate(RockPrefab, transform.position, RockPrefab.transform.rotation);
        Vector3 randomTorque = new Vector3(0, 0, Random.Range(0, 5));
        rockBody.AddTorque(randomTorque);
    }

    public void SpawnFallingRocks()
    {
        rockCount = Random.Range(0, 14);
        Instantiate(RockObject, transform.position, Quaternion.identity);
        rockSpawnDelay = Random.Range(1f, 4f);
        rockSpawnTime = Time.time;
    }
    public void EndGame()
    {
        Instantiate(RockObject, transform.position, Quaternion.identity);
    }

}