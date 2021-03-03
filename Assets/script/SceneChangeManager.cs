using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager instance;

    void Awake()
    {
        if (SceneChangeManager.instance == null)
        {
            SceneChangeManager.instance = this;
        }
    }
    public void MainMenu() 
    {
        SoundManager.instance.menu_Click();
        SceneManager.LoadScene(0);
    }

    public void GameStart() 
    {
        SoundManager.instance.menu_Click();
        SceneManager.LoadScene(2);
    }

    public void Tutorial() 
    {
        SoundManager.instance.menu_Click();
        SceneManager.LoadScene(1);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    public void Result()
    {
        SceneManager.LoadScene(3);
    }
}
