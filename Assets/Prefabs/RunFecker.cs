using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFecker : MonoBehaviour
{
    public Rigidbody2D Fecker;
    public GameObject Fecker1;
    public GameObject Fooker;
    public GameObject Fooker1;

    public float obSpeed;

    private void Start()
    {
        Physics2D.IgnoreCollision(Fooker.GetComponent<Collider2D>(), Fecker.GetComponent<Collider2D>());
    }
    void Update()
    {
        obSpeed = -8 - Time.time / .4f;
        Fecker1.transform.localScale = new Vector2(0.5f, 0.5f);
        Fecker.velocity = new Vector2(obSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Deathwall")
            Destroy(this.gameObject);
    }
}
