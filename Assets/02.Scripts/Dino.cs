using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    float moveSpeed = 1f;
    float moveSpeed2 = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed2 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed2 * Time.deltaTime, 0, 0);
        }
    }
}
