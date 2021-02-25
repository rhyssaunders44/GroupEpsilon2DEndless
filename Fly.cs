using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public int jumpNum;
    public int maxJump;
    public float thrust = 100f;
    public bool isGrounded;
    public GameObject Floor;
    public Rigidbody rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        maxJump = 1;
        jumpNum = 0;
    }

    void OnCollisionEnter()
    {
        if (OnCollisionEnter.gameObject.name == Floor) 
        { 
            jumpNum = 0; 
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
            rigidbody.AddForce(transform.up * 10 * thrust, ForceMode.Impulse);
            jumpNum++;
        }
    }
}
