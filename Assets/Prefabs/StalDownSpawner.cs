using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalDownSpawner : MonoBehaviour
{
    public float spawnTime;
    public float lastSpawn;
    public GameObject Stalagtite;

    private void Start()
    {
        lastSpawn = Random.Range(0f, 5f);
    }

    void Update()
    {


        if(Time.time > spawnTime + lastSpawn)
        {
            CreateFecker();
        }
    }

    void CreateFecker()
    {
        Instantiate(Stalagtite, transform.position, Quaternion.identity);
        lastSpawn = Random.Range(2, 7);
        spawnTime = Time.time;
    }
}
