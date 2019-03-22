using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    float timecounter = 0;
    float a, b, c;


    [SerializeField]
    private float speed;

    [SerializeField]
    private float width;

    [SerializeField]
    private float height;

    void Start()
    {
        Vector3 temp = transform.position;
        a = temp.x; 
        b = temp.y;
        c = temp.z;
    }


    // Update is called once per frame
    void Update()
    {
        timecounter += Time.deltaTime*speed;

        float x = Mathf.Cos(timecounter)*width + a;
        float z = Mathf.Sin(timecounter)* height+ c;
        float y = 50.0f;

        transform.position = new Vector3(x, y, z);
    }
}
