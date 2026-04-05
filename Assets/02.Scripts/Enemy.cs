using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State
    {
        Idle,
        Run
    }

    public float moveSpeed;
    public float detectRadius;
    private State state;
    private Transform targetRaptor;

    private void Start()
    {
        GetComponent<Animator>().speed = 0;
    }

    private void Update()
    {
        SetState();
    }

    private void SetState()
    {
        switch (state)
        {
            case State.Idle:
                DetectDino();
                break;

            case State.Run:
                GoToDino();
                break;
        }
    }

    private void DetectDino()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRadius);

        foreach(Collider colls in hitColliders)
        {
            if(colls.gameObject.GetComponent<Raptor>() != null)
            {
                if (colls.gameObject.GetComponent<Raptor>().IsTarget())
                    continue;
                colls.gameObject.GetComponent<Raptor>().SetTarget();

                targetRaptor = colls.gameObject.transform;
                Debug.Log(targetRaptor);

                StartGoToDino();
            }
        }
    }

    private void StartGoToDino()
    {
        state = State.Run;
        GetComponent<Animator>().speed = 1f;

    }

    private void GoToDino()
    {
        if(targetRaptor == null)
        {
            return;
        }
        Debug.Log(transform.position);
        Debug.Log(targetRaptor.position);
        Debug.Log(Time.deltaTime * moveSpeed);
        transform.position = Vector3.MoveTowards(transform.position, targetRaptor.position, Time.deltaTime * moveSpeed);
        Debug.Log(transform.position + " " + targetRaptor.position + " " + Time.deltaTime * moveSpeed);

        if(Vector3.Distance(transform.position, targetRaptor.position) < 0.1f)
        {
            Destroy(targetRaptor.gameObject);
            Destroy(this.gameObject);
        }
    }
}
