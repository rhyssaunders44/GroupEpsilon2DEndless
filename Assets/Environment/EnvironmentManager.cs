using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject[] BackGrounds;
    public SpriteRenderer[] BackGroundRenderers;
    int index;
    public GameObject[] Lights;
    float offset;
    public bool pause = false;
    float startup;

    void Start()
    {
        for (int index = 0; index < BackGrounds.Length; index++)
        {
            BackGroundRenderers[index] = BackGrounds[index].GetComponent<SpriteRenderer>();
        }
        startup = 0.1f;
        StartCoroutine("FadeIn");
    }

    void Update()
    {
        if (Time.timeScale >= 1 && pause == false)
            StopCoroutine("FadeIn");

        offset = Time.time;

        ScrollTexture(0, 0.01f);    // BackGround  
        ScrollTexture(1, 0.3f);     // BackGround Detail
        ScrollTexture(2, 0.7f);     // BackGround Floor

        foreach(GameObject light in Lights)
        {
            light.transform.position = new Vector3(light.transform.position.x - 6.055f * Time.deltaTime, light.transform.position.y, light.transform.position.z);

            if (light.transform.position.x < -10.2f)
            {
                light.transform.position = new Vector3(10.2f, light.transform.position.y, light.transform.position.z);
            }
        }
    }

    void ScrollTexture(int index, float scrollModifier)
    {
        BackGroundRenderers[index].material.SetTextureOffset("_MainTex", new Vector2(scrollModifier * offset, 0));
    }

    IEnumerator FadeIn()
    {
        while (true)
        {
            yield return Time.timeScale = startup + Time.time;
        }

    }
}
