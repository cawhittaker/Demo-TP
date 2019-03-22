using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorescreen : MonoBehaviour
{

    public Text scoretext;
    public Text highscoretext;

    float x;
    float y =Mathf.Infinity;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        x = PlayerPrefs.GetFloat("finishtime");
        string minutes = ((int)x / 60).ToString();
        string seconds = (x % 60).ToString("f2");
        scoretext.text = "Time Taken " + minutes + ":" + seconds;

        PlayerPrefs.SetFloat("highscore", y);

    }

    // Update is called once per frame
    void Update()
    {
        if (x < y)
        {
            PlayerPrefs.SetFloat("highscore", x);
        }

        z = PlayerPrefs.GetFloat("highscore");
        string minutes = ((int)x / 60).ToString();
        string seconds = (x % 60).ToString("f2");
        highscoretext.text = "Highscore  is " + minutes + ":" + seconds;


    }

}
