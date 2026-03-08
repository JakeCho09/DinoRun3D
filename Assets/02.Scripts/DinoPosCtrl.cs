using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPosCtrl : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < transform.childCount; i++)
        {
            float z = i * 1f;

            transform.GetChild(i).localPosition = Vector3.right * z;
        }
    }
}
