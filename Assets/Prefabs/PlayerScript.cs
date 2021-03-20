using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static bool alive;
    public GameObject Character;
    public float hozControl;
    public float sensitivity;
    public bool grounded;
    public int jumpNum;
    public int maxJump;
    public float thrust = 0.001f;
    public GameObject Floor;
    public Rigidbody2D playerRigid;

    private void Start()
    {
        sensitivity = 1.5f;
        alive = true;
        playerRigid = GetComponent<Rigidbody2D>();
        maxJump = 1;
        jumpNum = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            maxJump++;
        }


        if (Input.GetKeyDown(KeyCode.Space) && (jumpNum < maxJump))
        {
            playerRigid.AddForce(transform.up * 0.1f * thrust, ForceMode2D.Impulse);
            jumpNum++;
            grounded = false;
        }

        if (Input.GetKey(KeyCode.D) && grounded == true)
        playerRigid.velocity = new Vector2(1, 0);

        if (Input.GetKey(KeyCode.A) && grounded == true)
            playerRigid.velocity = new Vector2(-7, 0);

        if (alive == false)
        {
            Character.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "rockboi" || col.gameObject.tag == "fooker")
        {
            alive = false;
        }

        if (col.gameObject.name == "Floor")
        {
            jumpNum = 0;
            grounded = true;
        }
    }
}
