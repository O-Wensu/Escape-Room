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
            GameTimeText.text = "시간 : 0" + (int)GameTime;
            //text는 string 타입으로 (int)GameTime만 넣으면 안됨
        }
        else
            GameTimeText.text = "시간 : " + (int)GameTime;
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
        if (GameTime < 10)
        {
            resultTimeText.text = "소요 시간 : 0" + (int)GameTime;
            //text는 string 타입으로 (int)GameTime만 넣으면 안됨
        }
        else
            resultTimeText.text = "소요 시간 : " + (int)GameTime;
    }

    public void endTime()
    {

        if (GameTime < 10)
        {
            endTimeText.text = "소요 시간 : 0" + (int)GameTime;
            //text는 string 타입으로 (int)GameTime만 넣으면 안됨
        }
        else
            endTimeText.text = "소요 시간 : " + (int)GameTime;
    }

    public void setZero()
    {
        GameTime = startTime;
    }
}
