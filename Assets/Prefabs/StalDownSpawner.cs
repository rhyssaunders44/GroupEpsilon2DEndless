using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalDownSpawner : MonoBehaviour
{
    public float feckerTime;
    public float lastFecker;
    public GameObject Fecker;

    void Update()
    {

        if(Time.time > feckerTime + lastFecker)
        {
            CreateFecker();
        }
    }

    void CreateFecker()
    {
        Instantiate(Fecker, transform.position, Quaternion.identity);
        lastFecker = Random.Range(2, 7);
        feckerTime = Time.time;
    }
}
