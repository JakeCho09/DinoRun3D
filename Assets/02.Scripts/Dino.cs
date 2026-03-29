using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public static Dino instance;

    public Vector3 sphereCenter;
    public float sphereRadius = 0.5f;

    public DinoPosCtrl dinoPosCtrl;

    float moveSpeed = 4f;
    float moveSpeed2 = 10f;

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
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameStart.Equals(true))
        {
            DinoMove();
            DoorCheck();
        }
    }

    private void DoorCheck()
    {
        Collider[] hitCollision = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        foreach (Collider doors in hitCollision)
        {
            if(doors.CompareTag("Goal"))
            {
                Debug.Log("Goal");
                doors.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                Debug.Log("감지한 오브텍트" + doors.gameObject.name);

                int doorNum = doors.gameObject.GetComponent<SelectDoor>().GetDoorNum(transform.position.x);
                DoorType doorType = doors.gameObject.GetComponent<SelectDoor>().GetDoorType(transform.position.x);

                doors.gameObject.GetComponent<BoxCollider>().enabled = false;

                dinoPosCtrl.SetDoorCalc(doorType, doorNum);
            }
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
    private void DinoMove()
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

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.8f, 3.8f), transform.position.y, transform.position.z);
    }
}
