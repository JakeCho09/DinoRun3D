using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject titlep;
    public GameObject GP;

    public Slider PB;

    public TextMeshProUGUI nowStage;
    public TextMeshProUGUI nextStage;

    public bool isGameStart;

    private void Start()
    {
        //PlayerPrefs.DeleteKey("Stage");
        Time.timeScale = 0f;
        nowStage.text = MapManager.instance.GetStage().ToString();
        nextStage.text = (MapManager.instance.GetStage() + 1).ToString();
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

    private void Update()
    {
        SetDPB();
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
        //PlayerPrefs.DeleteKey("Stage");
        isGameStart = true;
        titlep.SetActive(false);
        GP.SetActive(true);
        Time.timeScale = 1f;
    }
}
