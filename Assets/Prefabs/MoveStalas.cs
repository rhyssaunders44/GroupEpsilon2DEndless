using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStalas : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public GameObject deathCollider;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(-12, rigidbody.transform.position.y);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag != "Floor" || collision.gameObject.tag != "Ceiling")
        {
            Destroy(gameObject);
        }
    }

}
