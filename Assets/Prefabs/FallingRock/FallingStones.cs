using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStones : MonoBehaviour
{
    public GameObject rockboi;
    public GameObject Character;

    public int rockCount;
    public bool alive;


    void Start()
    {
        alive = true;
        rockCount = 0;
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Character")
        {
            alive = false;
        }

        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Character")
        {
            Destroy(gameObject);
        }
    }

}
