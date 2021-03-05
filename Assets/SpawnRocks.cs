using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnRocks : MonoBehaviour
{
   
    public GameObject rockboi;
    public GameObject[] RockSpawn;

    public int rockCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float rockSpawnTime;
    public float rockSpawnDelay;
    public bool alive;


    void Start()
    {
        rockCount = 0;
        rockSpawnDelay = Random.Range(1f, 4f);

    }

    public void Update()
    {
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

    public void SpawnFallingRocks()
    {
        rockCount = Random.Range(0, 14);
        Instantiate(rockboi, RockSpawn[rockCount].transform.position, Quaternion.identity);
        rockSpawnDelay = Random.Range(1f, 4f);
        rockSpawnTime = Time.time;
    }
    public void EndGame()
    {
        Instantiate(rockboi, RockSpawn[rockCount].transform.position, Quaternion.identity);
        rockCount++;
        if (rockCount >= 20)
        {
            rockCount = 0;
        }
    }

}
