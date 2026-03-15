using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPosCtrl : MonoBehaviour
{
    public Transform raptors;

    public float radius = 1f;
    public float ratio = 0.1f;

    // Update is called once per frame
    void Update()
    {
        SetDinoPos();
        //float startPosX = (transform.childCount * -(dinogap / 2)) + (dinogap / 2);

        //for(int i = 0; i < transform.childCount;i++)
        //{
        //    transform.GetChild(i).localPosition = new Vector3(startPosX + (dinogap * i), 0, 0);
        //}
    }

    void SetDinoPos()
    {
        for(int i = 0; i < raptors.childCount; i++)
        {
            if(i > 8)
            {
                raptors.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            else
            {
                if(raptors.childCount < 10)
                {
                    float angleStep = 360f / (raptors.childCount * ratio);

                    float angle = i * angleStep;

                    float angleRad = angle * Mathf.Deg2Rad;

                    float x = Mathf.Cos(angleRad) * radius;
                    float z = Mathf.Sin(angleRad) * radius;

                    raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
                }
            }

        }

        //float angleStep = 360f / (raptors.childCount * ratio);

        //for (int i = 0; i < raptors.childCount; i++)
        //{
        //    float angle = i * angleStep;

        //    float angleRad = angle * Mathf.Deg2Rad;

        //    float x = Mathf.Cos(angleRad) * radius;
        //    float z = Mathf.Sin(angleRad) * radius;

        //    raptors.GetChild(i).localPosition = new Vector3(x, 0, z); 
        //}
    }
}
