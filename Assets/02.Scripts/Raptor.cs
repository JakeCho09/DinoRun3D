using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raptor : MonoBehaviour
{
    private bool isTarget;

    public void SetTarget()
    {
        isTarget = true;
    }

   public bool IsTarget()
    {
        return isTarget;
    }
}
