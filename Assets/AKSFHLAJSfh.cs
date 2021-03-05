using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKSFHLAJSfh : MonoBehaviour
{
    public int jumpNum;
    public int maxJump;
    public float thrust = 0.001f;
    public bool isGrounded;
    public GameObject Floor;
    public Rigidbody2D rb;
    public static bool grounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxJump = 1;
        jumpNum = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Floor")
        {
            jumpNum = 0;
            grounded = true;
        }



    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            maxJump++;
        }


        if (Input.GetKeyDown(KeyCode.Space) && (jumpNum < maxJump))
        {
            rb.AddForce(transform.up * 0.1f * thrust, ForceMode2D.Impulse);
            jumpNum++;
            grounded = false;
        }
    }
}