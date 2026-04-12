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

    [SerializeField] private bool isTargetOn;

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

        if (isTargetOn.Equals(true))
            return;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRadius);

        foreach(Collider colls in hitColliders)
        {
            Raptor raptor = colls.GetComponent<Raptor>();
            if (raptor != null && raptor.IsTarget().Equals(false))
            {
                Invoke("SetTargetDino", 0.1f);
                targetRaptor = raptor.transform;

                break; // 첫 번째 타겟만 설정하고 루프 중단

            }


            //if(colls.gameObject.GetComponent<Raptor>() != null)
            //{
            //    if (colls.gameObject.GetComponent<Raptor>().IsTarget())
            //        continue;
            //    colls.gameObject.GetComponent<Raptor>().SetTarget();

            //    targetRaptor = colls.gameObject.transform;
            //    Debug.Log(targetRaptor);

            //    StartGoToDino();
            //}
        }
    }

    private void SetTargetDino()
    {
        if (targetRaptor != null && targetRaptor.GetComponent<Raptor>().IsTarget().Equals(false))
        {
            targetRaptor.GetComponent<Raptor>().SetTarget();
            isTargetOn = true;

            StartGoToDino();
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
            SoundManager.instance.DinoHitPlay();
            Destroy(targetRaptor.gameObject);
            Destroy(this.gameObject);
        }
    }
}
