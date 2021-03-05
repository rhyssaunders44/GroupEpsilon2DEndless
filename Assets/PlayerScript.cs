using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static bool alive;
    public GameObject Character;
    public float hozControl;
    public float sensitivity;
    public Rigidbody2D character;
    public bool grounded;

    private void Start()
    {
        sensitivity = 1.5f;
        alive = true;
    }

    private void Update()
    {
        grounded = AKSFHLAJSfh.grounded;



        if(Input.GetKey(KeyCode.D) && grounded == true)
        character.velocity = new Vector2(1, 0);


        if (Input.GetKey(KeyCode.A) && grounded == true)
            character.velocity = new Vector2(-7, 0);




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
    }
}
