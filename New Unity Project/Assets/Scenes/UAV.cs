using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UAV : MonoBehaviour
{
    private GameObject target = null;
    private GameObject target2 = null;
    public GameObject closest= null;

    public GameObject[] Array;
    
    
    [SerializeField]
    private float moveSpeed;

    public GameObject Target { get => target; set => target = value; }
    public GameObject Target2 { get => target2; set => target2 = value; }
   

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("egg");
        target2 = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Roam();
        
    }

    public GameObject Findclosestegg()
    {
        Array = GameObject.FindGameObjectsWithTag("egg");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in Array)
        {
            Vector3 Diff = go.transform.position - position;
            float curDistance = Diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void Roam()
    {
        closest = Findclosestegg();
        
        int length = Array.Length;
       
        
        if (length >= 0 && length < 3)
        {
            transform.LookAt(target2.transform);
            
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

            var direction = (target2.transform.position - transform.position).normalized;
            direction.y = 0;
            var amount = direction * moveSpeed * Time.deltaTime;

            var pos = transform.position;
            pos += amount;
            transform.position = pos;
        }

        else
        {
            if (!closest) { return; }

            transform.LookAt(closest.transform);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);

            var direction = (closest.transform.position - transform.position).normalized;
            direction.y = 0;
            var amount = direction * moveSpeed * Time.deltaTime;

            var pos = transform.position;
            pos += amount;
            transform.position = pos;

            if ((transform.position - closest.transform.position).magnitude < 11.32)
            {
                Destroy(closest);
            }
        }

    }


}
