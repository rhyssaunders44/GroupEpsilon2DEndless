using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefab;
    public int spawnIndex;
    public Transform[] spawnpoints;
    public Vector3 spawnPos;
    public int count;

    void Start()
    {
        count = transform.childCount;
        spawnpoints = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            spawnpoints[i] = transform.GetChild(i);
        }

        InvokeRepeating("spawnEnemys", 1, 5);
    }

    void spawnEnemys()
    {
        spawnIndex = Random.Range(0, count);

        Instantiate(enemyPrefab, spawnpoints[spawnIndex].position, enemyPrefab.transform.rotation);
    }
}