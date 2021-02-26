using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStones : MonoBehaviour
{
    public GameObject rockboi;
    public GameObject RockSpawn;

    // Start is called before the first frame update
    void Start()
    {
        RockSpawn = GameObject.Find("RockSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(rockboi, new Vector3(0, 5, 0), Quaternion.identity);
        }
    }

    public Transform gameobject;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "player")
        {
            Destroy(gameObject);

        }

    }
      


}
