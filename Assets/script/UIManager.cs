using System;
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

    //싱글톤
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
        startTime = 0f;
    }
    void Update()   //시간 출력 소수 둘째자리까지
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
    public void GamePause() //게임 일시정지
    {
        stopPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()   //게임 계속하기
    {
        SoundManager.instance.menu_Click();
        stopPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void printTime() //라운드 끝나면 소요시간 출력, 점수 입력
    {
        Time.timeScale = 0f;
        total = total + (float)GameTime;
        if (GameTime < 10)
        {
            resultTimeText.text = "소요 시간 : 0" + (System.Math.Truncate(GameTime * 100) / 100) + "초";
            //text는 string 타입으로 (int)GameTime만 넣으면 안됨
        }
        else
        {
            resultTimeText.text = "소요 시간 : " + (System.Math.Truncate(GameTime * 100) / 100) + "초";
        }
        if ((GameManager.instance.level == 1)||(GameManager.instance.level==2))
        {
            if (GameTime <= 5)
                gameScore += 100;
            if ((GameTime > 5) && (GameTime <= 15))
                gameScore += 60;
            if ((GameTime > 15) && (GameTime <= 20))
                gameScore += 30;
            if (GameTime > 20)
                gameScore += 5;
        }
        if ((GameManager.instance.level == 3)||(GameManager.instance.level==4))
        {
            if (GameTime <= 10)
                gameScore += 100;
            if ((GameTime > 10) && (GameTime <= 15))
                gameScore += 60;
            if ((GameTime > 15) && (GameTime <= 25))
                gameScore += 40;
            if (GameTime > 25)
                gameScore += 10;
        }

        scoreText.text = "점수 : " + gameScore + "점";
    }

    public void endTime()
    {
        Debug.Log(total);
        endTimeText.text = "게임시간 : " + (System.Math.Truncate(total * 100) / 100) + "초";
    }

    public void EndScore()  //게임 모두 끝났을 때 시간 당 점수 추가, 디비 입력
    {
        endScore.text = "점수 : " + gameScore+"점";

        float playtime_REAL = (float)(Math.Truncate(total * 100) / 100);
        /*string sql = string.Format("Insert into Game(date, userID, gameID, gamePlayTime, gameScore) " +
                                                   "VALUES( {0}, {1}, {2}, {3}, {4})",
                                                   sqlite.Instance.date, sqlite.Instance.userID, sqlite.Instance.gameID, playtime_REAL, gameScore);
        Debug.Log("sqlite.Instance.date : " + sqlite.Instance.date);
        sqlite.Instance.DatabaseSQLAdd(sql);*/

        string sql = string.Format("Insert into Game(date, userID, gameID, angleOfRotation, gamePlayTime, gameScore) " +
        "VALUES( {0}, {1}, {2}, {3}, {4}, {5} )", sqlite.Instance.date, sqlite.Instance.userID, sqlite.Instance.gameID, GameManager.instance.num1 * 360, playtime_REAL, gameScore);
        Debug.Log("sqlite.Instance.date : " + sqlite.Instance.date);
        sqlite.Instance.DatabaseSQLAdd(sql);
    }

    public void setZero()   //게임 시간 0으로 초기화
    {
        GameTime = startTime;
    }
    public void Restartbtn()    //재시작 버튼
    {
        SceneChangeManager.instance.GameStart();
        stopPanel.SetActive(false);
    }
}
