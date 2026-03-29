using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPosCtrl : MonoBehaviour
{
    public Transform raptors;
    public GameObject raptorPrefab;

    public int visibleRaptorNum;
    public float initialRadius = 0f;
    public float radiusGrowth = 0.12f;
    public float goldenAngle = 137.508f;

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

    public void SetDoorCalc(DoorType doorType, int doorNumber)
    {
        if(doorType.Equals(DoorType.Plus))
        {
            PlusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Minus))
        {
            MinusRaptor(doorNumber);
        }
        else if (doorType.Equals(DoorType.Times))
        {
            int raptorNum = raptors.childCount * (doorNumber - 1);
            TimesRaptor(raptorNum);
        }
        else if (doorType.Equals(DoorType.Division))
        {
            int raptorNum = raptors.childCount - (raptors.childCount / doorNumber);
            MinusRaptor(raptorNum);
        }
    }

    private void PlusRaptor(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(raptorPrefab, raptors);
        }
    }

    private void MinusRaptor(int number)
    {
        if (number > raptors.childCount)
        {
            number = raptors.childCount;
        }

        int raptorNum = raptors.childCount;

        for (int i = raptorNum - 1; i >= (raptorNum - number); i -- )
        {
            Destroy(raptors.GetChild(i).gameObject); //맨 마지막 오브젝트 부터 삭제
        }
    }


    private void TimesRaptor(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(raptorPrefab, raptors);
        }
    }

    void SetDinoPos()
    {
        for(int i = 0; i < raptors.childCount; i++)
        {
            if(i > visibleRaptorNum - 1)
            {
                raptors.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            else
            {
                if(i < visibleRaptorNum)
                {
                    float currentRadius = initialRadius + (radiusGrowth * i);

                    float angle = i * goldenAngle;

                    float angleRad = angle * Mathf.Deg2Rad;

                    float x = Mathf.Cos(angle*Mathf.Deg2Rad) * currentRadius;
                    float z = Mathf.Sin(angleRad*Mathf.Deg2Rad) * currentRadius;

                    raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
                    raptors.GetChild(i).gameObject.SetActive(true);
                }
            }

        }
        //황금각은 137.508

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
