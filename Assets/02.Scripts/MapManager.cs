using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapPrefabs;

    int count = 0;

    float mapPosX = 0f;
    float mapPosZ = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int random = Random.Range(0, mapPrefabs.Length);

        if(count < 10)
        {
            GameObject mp = Instantiate(mapPrefabs[random]);

            if(random == 0)
            {
                mp.transform.position = new Vector3(mapPosX, 4.6f, mapPosZ + 5f);
                mapPosZ = mapPosZ + 10f;
                count = count + 1;
            }

            if(random == 1)
            {
                mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 10f);
                mapPosZ = mapPosZ + 20f;
                count = count + 1;
            }

            if (random == 2)
            {
                mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 15f);
                mapPosZ = mapPosZ + 30f;
                count = count + 1;
            }
        }
    }
}
