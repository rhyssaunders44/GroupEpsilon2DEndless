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
    public float thrust;
    public GameObject Floor;
    public Rigidbody2D playerRigid;
    public static float deathTime;

    private void Start()
    {
        sensitivity = 1.5f;
        alive = true;
        maxJump = 1;
        jumpNum = 0;
        thrust = 10f;
    }
   

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (jumpNum < maxJump))
        {
            playerRigid.AddForce(Character.transform.up * thrust, ForceMode2D.Impulse);
            jumpNum++;
        }


        if (!alive)
        {
            Character.SetActive(false);
            GameOver();
        }
    }

    public void FixedUpdate()
    {
        //this should probably use velocity
        if (Input.GetKey(KeyCode.D) && grounded && Character.transform.position.x < 6)
            playerRigid.AddForce(Vector2.right * 4, ForceMode2D.Force);

        if (Input.GetKey(KeyCode.A) && grounded)
            playerRigid.AddForce(-Vector2.right * 12, ForceMode2D.Force);
    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "rockboi" || col.gameObject.tag == "obstacle" || col.gameObject.tag == "deathWall")
        {
            alive = false;
        }

        if (col.gameObject.name == "Floor")
        {
            jumpNum = 0;
            grounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    void GameOver()
    {
        Time.timeScale = 0;
        deathTime = Time.time;
    }
}
