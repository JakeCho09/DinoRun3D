using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaptors : MonoBehaviour
{
    public GameObject enemyRaptorPrefab;
    public int enemyRaptorNumber;

    public Transform enemyRaptorParent;

    public float initialRadius = 0f;
    public float radiusGrowth = 0.12f;
    public float angleincrement = 137.5f;

    private void Start()
    {
        CreateEnemyRaptors();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void CreateEnemyRaptors()
    {
        for (int i = 0; i < enemyRaptorNumber; i++)
        {
            float currentRad = initialRadius + (radiusGrowth * 1);

            float angle = i * angleincrement;

            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * currentRad;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * currentRad;

            GameObject enemyRaptor = Instantiate(enemyRaptorPrefab, enemyRaptorParent);
            enemyRaptor.gameObject.transform.localPosition = new Vector3(x, 0, z);
        }
    }
}
