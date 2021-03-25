using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioMixer volumeAdjust;
    public AudioSource musicOutput;
    public Text volumePercent;

    public Sprite[] numbers;
    public float score;

    public Image[] scoreBoard;
    public int singleNum;
    public float timeFactor;

    public GameObject OptionsMenu;
    float hideOptionsMenu = 7;
    float showOptionsMenu = 0;

    int tens = 0;
    int hund = 0;
    int thous = 0;
    int tenThous = 0;
    int arraykeeper = 0;
    int looper = 0;
    bool pause;

    public void ChangeVolume(float volume)
    {
        volumeAdjust.SetFloat("volume", volume);
        volumePercent.text = (volume * 100).ToString() + " %";

    }

    public void Mute()
    {
        musicOutput.mute = !musicOutput.mute;
    }


    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    void Start()
    {
        singleNum = 0;
    }
    void Update()
    {
        #region Score
        timeFactor = Time.time * 3;

        score = timeFactor - arraykeeper;

        singleNum = (int)score;
        if (singleNum >= 10)
        {
            singleNum = 0;
            looper++;
            tens++;
            arraykeeper = 10 * looper;
        }

        if (tens >= 10)
        {
            tens = 0;
            hund++;
        }

        if (hund >= 10)
        {
            hund = 0;
            thous++;
        }

        if (thous >= 10)
        {
            thous = 0;
            tenThous++;
        }

        scoreBoard[0].sprite = numbers[singleNum];
        scoreBoard[1].sprite = numbers[tens];
        scoreBoard[2].sprite = numbers[hund];
        scoreBoard[3].sprite = numbers[thous];
        scoreBoard[4].sprite = numbers[tenThous];
        #endregion

        if (Input.GetKeyDown(KeyCode.P) && Time.time > 3f)
        {
            OptionsEnable();
            pause = true;
        }
    }

    void OptionsEnable()
    {
        if (pause == true)
        {
            OptionsMenu.transform.position = new Vector2(OptionsMenu.transform.position.x, Mathf.Lerp(transform.position.y, showOptionsMenu, 3f));
            Time.timeScale = 0;
        }
        else
        {
            OptionsMenu.transform.position = new Vector2(OptionsMenu.transform.position.x, Mathf.Lerp(transform.position.y, showOptionsMenu, 3f));
            Time.timeScale = 1;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

}
