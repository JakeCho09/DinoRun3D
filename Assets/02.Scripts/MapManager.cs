using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    //public GameObject[] mapPrefabs;
    public StageScriptabeObject[] stages;
    public GameObject goalObject;
    public GameObject RealGoal;
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

    public int GetStage()
    {
        return PlayerPrefs.GetInt("Stage", 1);
    }

    void Start()
    {
        GetStage();
        CreatStage();
        goalObject = GameObject.FindWithTag("Goal");
        //Instantiate(mapPrefabs[5]).transform.position = new Vector3(mapPosX, 4.6f, mapPosZ + 15f);
        //mapPosZ = mapPosZ + 30f;
    }

    // Update is called once per frame
   

    public float GetGoalDistance()
    {
        return goalObject.transform.position.z;
    }

    //void CreateMap()
    //{
    //    int random = Random.Range(0, mapPrefabs.Length);

    //    if (count < 10)
    //    {
    //        GameObject mp = Instantiate(mapPrefabs[random]);

    //        if (random == 0)
    //        {
    //            mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 5f);
    //            mapPosZ = mapPosZ + 10f;
    //            count = count + 1;
    //        }

    //        if (random == 1)
    //        {
    //            mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 10f);
    //            mapPosZ = mapPosZ + 20f;
    //            count = count + 1;
    //        }

    //        if (random == 2)
    //        {
    //            mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 15f);
    //            mapPosZ = mapPosZ + 30f;
    //            count = count + 1;
    //        }

    //        if (random == 3)
    //        {
    //            mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 5f);
    //            mapPosZ = mapPosZ + 10f;
    //            count = count + 1;
    //        }

    //        if (random == 4)
    //        {
    //            mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 10f);
    //            mapPosZ = mapPosZ + 20f;
    //            count = count + 1;
    //        }

    //        if (random == 5)
    //        {
    //            mp.transform.position = new Vector3(0, 4.6f, mapPosZ + 15f);
    //            mapPosZ = mapPosZ + 30f;
    //            count = count + 1;
    //        }
    //    }

    //    if (count == 10)
    //    {
    //        RealGoal = Instantiate(goalObject);
    //        RealGoal.transform.position = new Vector3(0, 4.6f, mapPosZ + 15f);
    //        mapPosZ = mapPosZ + 30f;
    //        count = count + 1;
    //    }
    //}

    private void CreatStage()
    {
        int currentStageIndex = GetStage();
        currentStageIndex = currentStageIndex % stages.Length;
        StageScriptabeObject stage = stages[currentStageIndex];

        CreateMap(stage.maps);
    }

    private void CreateMap(Map[] stageMaps)
    {
        Vector3 mapPosision = Vector3.zero;

        for (int i = 0; i<stageMaps.Length; i++)
        {
            Map selectedMap = stageMaps[i];
            if(i>0)
            {
                mapPosision.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            Map nowMap = Instantiate(selectedMap, mapPosision, Quaternion.identity, transform);
            mapPosision.z += nowMap.GetComponent<Map>().GetMapSize() / 2;
        }
    }
}
