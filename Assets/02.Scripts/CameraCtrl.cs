using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject Dino;
    // Update is called once per frame
    void Update()
    {
        Vector3 DinoPos = Dino.transform.position;

        transform.position = new Vector3(0, 8, DinoPos.z - 5);
    }
}
