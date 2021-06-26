using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStones : MonoBehaviour
{
    public GameObject Rock;
    public Rigidbody2D rockBody;

    void Start()
    {
        rockBody = GetComponent<Rigidbody2D>();
        float randomTorque = Random.Range(-5,5);
        rockBody.AddTorque(randomTorque);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "Ceiling")
            Destroy(gameObject);
    }

}
