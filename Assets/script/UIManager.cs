using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float GameTime = 0;
    public Text GameTimeText;
    public GameObject stopPanel;
    public Text resultTimeText;
    public Text endTimeText;
    private float startTime;
    private float total=0;
    public Text scoreText;
    public Text endScore;
    private int gameScore = 0;

    public static UIManager instance;
    void Awake()
    {
        if (UIManager.instance == null)
        {
            UIManager.instance = this;
        }
    }
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        GameTime = GameTime + Time.deltaTime;
        if (GameTime < 10)
        {
            GameTimeText.text = "시간 : 0" + (System.Math.Truncate(GameTime * 100) / 100);
            //text는 string 타입으로 (int)GameTime만 넣으면 안됨
        }
        else
            GameTimeText.text = "시간 : " + (System.Math.Truncate(GameTime * 100) / 100);
    }
    public void GamePause()
    {
        stopPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SoundManager.instance.menu_Click();
        stopPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void printTime()
    {
        Time.timeScale = 0f;
        total = total + (float)GameTime;
        if (GameTime < 10)
        {
            resultTimeText.text = "소요 시간 : 0" + (System.Math.Truncate(GameTime * 100) / 100) + "초";
            if (GameTime <= 5)
                gameScore += 100;
            if((GameTime>5)&&(GameTime<=10))
                gameScore += 70;
            //text는 string 타입으로 (int)GameTime만 넣으면 안됨
        }
        else
        {
            resultTimeText.text = "소요 시간 : " + (System.Math.Truncate(GameTime * 100) / 100) + "초";
            if (GameTime <= 15)
                gameScore += 50;
            if (GameTime > 15)
                gameScore += 30;
        }
        scoreText.text = "점수 : " + gameScore + "점";
    }

    public void endTime()
    {
        Debug.Log(total);
        endTimeText.text = "게임시간 : " + (System.Math.Truncate(total * 100) / 100) + "초";
    }

    public void EndScore()
    {
        endScore.text = "점수 : " + gameScore+"점";
    }

    public void setZero()
    {
        GameTime = startTime;
    }
    public void Restartbtn()
    {
        SceneChangeManager.instance.GameStart();
        stopPanel.SetActive(false);
    }
}
