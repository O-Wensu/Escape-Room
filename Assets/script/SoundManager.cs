using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region 
    public AudioClip menu_sound; //버튼 소리
    public AudioClip menu_door; //문 버튼 소리
    public AudioClip success_sound; //성공 소리
    public AudioClip door_sound; //문 열리고 탈출하는 소리
    public AudioClip cave_sound; //동굴 무너지는 소리
    AudioSource myAudio; //음악 플레이어
    #endregion

    #region Singleton
    public static SoundManager instance;

    void Awake()
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }
    #endregion

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void menu_Click()    //일반 메뉴
    {
        myAudio.PlayOneShot(menu_sound);
    }
    public void menu_Door() //문 버튼 클릭
    {
        myAudio.PlayOneShot(menu_door);
    }
    public void Success()   //잠금 엶
    {
        myAudio.PlayOneShot(success_sound);
    }
    public void OpenDoor()  //탈출하는 소리
    {
        myAudio.PlayOneShot(door_sound);
    }
    public void Cave()  //동굴 무너지는 소리
    {
        myAudio.PlayOneShot(cave_sound);
    }
}
