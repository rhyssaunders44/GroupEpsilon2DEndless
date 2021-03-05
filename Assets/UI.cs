using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreCount;
    public bool alive;
    public float deathTime;
    
    // Update is called once per frame
    void Update()
    {

        alive = PlayerScript.alive;
        if (alive == true)
            DeathTime();
        else
        {

        }

    }
    void DeathTime()
    {
        deathTime = Mathf.Round(Time.time * 12f);
        scoreCount.text = Mathf.Round(Time.time * 12f).ToString();
    }
}
