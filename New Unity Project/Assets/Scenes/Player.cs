using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public Text eggtext;
    public Text timertext;
    //public Text scoretext;
    private float starttime;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpAmount;

    private Rigidbody rb;

    public GameObject[] Array;

    private GameObject target = null;
    public GameObject Target { get => target; set => target = value; }

    public float ftime;



    public void PlayGame()
    {
        SceneManager.LoadScene("Winner");
    }

    public void finaltime()
    {
        ftime = Time.time - starttime;
        PlayerPrefs.SetFloat("finishtime", ftime);
        //string minutes = ((int)ftime / 60).ToString();
        //string seconds = (ftime % 60).ToString("f2");
        //scoretext.text = "Time Taken " + minutes + ":" + seconds;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.CompareTag("egg"))
        {
            //collision.other.transform.parent = transform;
            collision.other.tag = "owned";
            collision.other.GetComponent<Enemy>().Target = gameObject;
        }

       
        else if (collision.other.CompareTag("owned"))
        {
            collision.other.GetComponent<Rigidbody>().AddForce((collision.other.transform.position - transform.position).normalized * 1000f);
        }
    }


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Spider");
        rb = GetComponent<Rigidbody>();
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Array = GameObject.FindGameObjectsWithTag("owned");
        int amount = Array.Length;
        if (amount > 0)
        {
            eggtext.text = "Eggs Left : " + (20 - amount).ToString("0");
        }

        else
        {
            eggtext.text = "Eggs Left : " + (20).ToString("0");
        }

        if(amount == 20)
        {
            finaltime();
            PlayGame();
            
        }

        CheckInputs();
    }

    private void CheckInputs()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime*0.5f;
            transform.position = temp;
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime * 0.5f;
            transform.position = temp;
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 temp = transform.position;
            temp.z -= speed * Time.deltaTime * 0.5f;
            transform.position = temp;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 temp = transform.position;
            temp.z += speed * Time.deltaTime * 0.5f;
            transform.position = temp;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -45, 0));
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 135, 0));
        }
    
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 225, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           rb.velocity = new Vector3(0, 1, 0) * jumpAmount;
        }

        if ((transform.position - target.transform.position).magnitude < 1.2)
        {
            Array = GameObject.FindGameObjectsWithTag("owned");
            int amount = Array.Length;

            System.Random rnd = new System.Random();
            int card = rnd.Next(amount);
            for (int i = 0; i < card; i++)
            {
                Destroy(Array[i]);
            }

        }

        float t = Time.time - starttime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timertext.text = "Time " + minutes + ":" + seconds;
    }
}
