using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private GameObject target = null;

    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float moveSpeed;

    public GameObject Target { get => target; set => target = value; }

   
    // Update is called once per frame
    void Update()
    {
        if(target != null && (transform.position - target.transform.position).magnitude > minDistance)
        {
            var direction = (target.transform.position - transform.position).normalized;
            var amount = direction * moveSpeed * Time.deltaTime;

            var pos = transform.position;
            pos += amount;
            transform.position = pos;
        }
    }
}
