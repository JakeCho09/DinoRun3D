using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    public GameObject[] mapPrefabs;
    public GameObject goalObject;
    int count = 0;

    float mapPosX = 0f;
    float mapPosZ = 0f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        Instantiate(mapPrefabs[5]).transform.position = new Vector3(mapPosX, 4.6f, mapPosZ + 15f);
        mapPosZ = mapPosZ + 30f;
    }

    // Update is called once per frame
    void Update()
    {
        CreateMap();
    }

    public float GetGoalDistance()
    {
        return goalObject.transform.position.z;
    }

    void CreateMap()
    {
        int random = Random.Range(0, mapPrefabs.Length);

        if (count < 10)
        {
            GameObject mp = Instantiate(mapPrefabs[random]);

            if (random == 0)
            {
                mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 5f);
                mapPosZ = mapPosZ + 10f;
                count = count + 1;
            }

            if (random == 1)
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

            if (random == 3)
            {
                mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 5f);
                mapPosZ = mapPosZ + 10f;
                count = count + 1;
            }

            if (random == 4)
            {
                mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 10f);
                mapPosZ = mapPosZ + 20f;
                count = count + 1;
            }

            if (random == 5)
            {
                mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 15f);
                mapPosZ = mapPosZ + 30f;
                count = count + 1;
            }
        }

        if (count == 10)
        {
            Instantiate(goalObject).transform.position = new Vector3(0, 4.6f, mapPosZ + 15f);
            mapPosZ = mapPosZ + 30f;
            count = count + 1;
        }
    }
}
