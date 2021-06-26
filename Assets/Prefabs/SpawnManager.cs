using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject RockPrefab;
    public GameObject RockSpawner;
    public GameObject Stalagmite;
    public GameObject Stalagtite;
    public GameObject miteSpawn;
    public GameObject titeSpawn;
    public float nextSpawnTime;
    public float lastSpawnTime;
    public int spawnrandomiser;
    public static float spawnTime;

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

    }

    private void Update()
    {
        float distance;
        spawnTime = Time.time;
        distance = transform.position.x - newLocation.x;
        float speed = 6f;
        float step = speed * Time.deltaTime;

        if (Time.time >= rockSpawnTime + rockSpawnDelay)
        {
            SpawnFallingRocks();
            NewWayPoint();
        }


        RandomSpawn();

        if (Time.time >= nextSpawnTime)
        {
            if (spawnrandomiser == 0)
            {
                SpawnObstacle(miteSpawn, Stalagmite);
            }

            if (spawnrandomiser == 1)
            {
                SpawnObstacle(titeSpawn, Stalagtite);
            }

            if(spawnrandomiser == 2)
            {
                SpawnObstacle(titeSpawn, Stalagtite);
                nextSpawnTime = Time.time;
                SpawnObstacle(miteSpawn, Stalagmite);
            }

        }

        #region spawnmover
        distance = Mathf.Abs(transform.position.x - newLocation.x);
        transform.position = Vector2.MoveTowards(transform.position, newLocation, step);


        #endregion
    }

    Vector2 NewWayPoint()
    {
        int randX = Random.Range(-4, 6);
        newLocation = new Vector2(randX, transform.position.y );
        return newLocation;
    }

    void SpawnObstacle(GameObject Spawner, GameObject SpawnedObject)
    {
        Instantiate(SpawnedObject, Spawner.transform.position, Quaternion.identity);
        lastSpawnTime = Time.time;
        nextSpawnTime = lastSpawnTime + Random.Range(3, 10);

    }

    void SpawnFallingRocks()
    {
        Instantiate(RockPrefab, new Vector3(RockSpawner.transform.position.x, RockSpawner.transform.position.y, -2),Quaternion.identity);
        rockSpawnDelay = Random.Range(1f, 4f);
        rockSpawnTime = Time.time;
    }

    void RandomSpawn()
    {
        spawnrandomiser = Random.Range(0, 2);

    }
}