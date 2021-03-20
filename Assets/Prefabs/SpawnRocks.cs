using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnRocks : MonoBehaviour
{
   
    public GameObject RockObject;




    void Start()
    {
        rockCount = 0;
        rockSpawnDelay = Random.Range(1f, 4f);
    }

    public void Update()
    {

    }


}
