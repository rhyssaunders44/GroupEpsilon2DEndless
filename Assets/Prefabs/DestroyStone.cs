using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStone : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Character")
        {
            Destroy(gameObject);
        }
    }
}
