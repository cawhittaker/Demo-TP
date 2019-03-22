using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAVlight : MonoBehaviour
{

    private GameObject target = null;

    public GameObject Target { get => target; set => target = value; }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("UAV");
    }

    // Update is called once per frame
    void Update()
    {
        float x_co = target.transform.position.x;
        float z_co = target.transform.position.z;
        Vector3 temp = transform.position;
        temp.x = x_co;
        temp.y = 12.0f;
        temp.z = z_co;
        transform.position = temp;
    }
}
