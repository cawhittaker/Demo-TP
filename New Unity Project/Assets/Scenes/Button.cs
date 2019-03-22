using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Button : MonoBehaviour
{
    //public Text scoretext;

    //float x;
    // Start is called before the first frame update
    void Start()
    {
        //x = GameObject.Find("Dragon").GetComponent<Player>().ftime;
       

    }

    // Update is called once per frame
    void Update()
    {
        //x = GameObject.Find("Dragon").GetComponent<Player>().ftime;
        //string minutes = ((int)x / 60).ToString();
        //string seconds = (x % 60).ToString("f2");
        //scoretext.text = "Time Taken " + minutes + ":" + seconds;

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
