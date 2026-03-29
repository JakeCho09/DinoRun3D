using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject titlep;
    public GameObject GP;

    public Slider PB;

    public bool isGameStart;

    private void Start()
    {
        Time.timeScale = 0f;
        PB.value = 0f;
        titlep.SetActive(true);
        GP.SetActive(false);
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void SetDPB()
    {
        if (isGameStart.Equals(false))
        {
            return;
        }

        float goalDistance = Dino.instance.transform.position.z / MapManager.instance.GetGoalDistance();
        PB.value = goalDistance;
    }

    public void GameStart()
    {
        Debug.Log("게임 시작");
        isGameStart = true;
        titlep.SetActive(false);
        GP.SetActive(true);
        Time.timeScale = 1f;
    }
}
