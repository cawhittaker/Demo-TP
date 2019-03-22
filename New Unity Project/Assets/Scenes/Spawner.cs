using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Eggprefab;
    public Vector3 centre;
    public Vector3 size;

    public float spawnrate = 1.0f;
   

    // Start is called before the first frame update
    void Start()
    {
        //Spawnegg();
    }

    // Update is called once per frame
    void Update()
    {
        print(spawnrate);
        if(Random.value < spawnrate * Time.deltaTime)
        {
            Spawnegg();
        }
    }

    public void Spawnegg()
    {
        Vector3 pos = centre + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(Eggprefab, pos, Quaternion.identity);
    }


    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawCube(centre,size);
    }
}
