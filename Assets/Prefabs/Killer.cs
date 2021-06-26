using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public GameObject stalagmite;
    public GameObject stalagtite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "obstacle")
        {
            Destroy(collision.gameObject);
        }
    }
}
