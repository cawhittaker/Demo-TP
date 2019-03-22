using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{


    private GameObject target = null;

    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float moveSpeed;

    private Rigidbody sp;

    public GameObject Target { get => target; set => target = value; }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null && (transform.position - target.transform.position).magnitude > minDistance)
        {

            transform.LookAt(target.transform);

            var direction = (target.transform.position - transform.position).normalized;
            var amount = direction * moveSpeed * Time.deltaTime;

            var pos = transform.position;
            pos += amount;
            transform.position = pos;
        }

        if (target != null && (transform.position - target.transform.position).magnitude < minDistance)
        {

            transform.LookAt(target.transform);

            var direction = (target.transform.position - transform.position).normalized;
            var amount = direction * moveSpeed * 0.2f * Time.deltaTime;

            var pos = transform.position;
            pos += amount;
            transform.position = pos;
        }

        if ((transform.position - target.transform.position).magnitude < 1.5f)
        {
            GetComponent<Animation>().clip = GetComponent<Animation>().GetClip("attack1");
            GetComponent<Animation>().Play();
        }

        else if (transform.position.y > 0.8f)
        {
            GetComponent<Animation>().clip = GetComponent<Animation>().GetClip("jump");
            GetComponent<Animation>().Play();
        }

        else
        {
            GetComponent<Animation>().clip = GetComponent<Animation>().GetClip("run");
            GetComponent<Animation>().Play();
        }
    }
 }

