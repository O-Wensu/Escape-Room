using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region
    private int level = 1;
    public Text CodeText;
    private List<int> codeNum = new List<int>();
    private List<int> ShowCode = new List<int>();
    private int randNum;
    private string line;
    public Text[] firstCode;
    public Text[] secondCode;
    public Text[] thirdCode;
    public Text[] fourthCode;
    public Text LastText;
    public GameObject[] dial;
    public GameObject[] arrow;
    private int[] Pos = new int[4];
    private bool firstCheck = false;
    private bool secondCheck = false;
    private bool thirdCheck = false;
    private bool fourthCheck = false;
    public Slider slider;
    private float preValue = 50f;
    private float nowValue = 50f;
    public Text sliderValue;
    public GameObject resultPanel;
    public GameObject[] scene;
    public GameObject Key;
    public GameObject clearPanel;
    public GameObject redPanel;

    #endregion

    public static GameManager instance;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.setZero();
        Time.timeScale = 0f;
    }
    void Update()
    {
        GameSuccess();
    }
    public void GamePlay()
    {
        UIManager.instance.setZero();
        Key.SetActive(true);
        Time.timeScale = 1f;
        for (int i = 0; i < 5; i++)
        {
            randNum = Random.Range(0, 99);
            codeNum.Add(randNum);
            ShowCode.Add(randNum);
        }
        if(level==1)
            ShowCode.RemoveRange(0, 2);
        if(level==2)
            ShowCode.RemoveRange(0, 1);
        line = string.Join(" ", ShowCode.ToArray());
        CodeText.text = "암호 : " + line;

        if (level == 1)
        {
            arrow[2].SetActive(true);
            firstCheck = true;
            secondCheck = true;
            Lv1ThirdTextPos();
            LastText.text = "" + (int)codeNum[4];
        }
        else if (level == 2)
        {
            firstCheck = true;
            dial[1].SetActive(true);
            arrow[1].SetActive(true);
            Lv2SecondTextPos();
            LastText.text = "" + (int)codeNum[4];
        }
        else if (level == 3)
        {
            dial[0].SetActive(true);
            arrow[0].SetActive(true);
            Lv3FirstTextPos();
            LastText.text = "" + (int)codeNum[4];
        }
        else if (level == 4)
        {
            arrow[0].SetActive(true);
            Lv4FirstTextPos();
            LastText.text = "" + (int)codeNum[4];
        }
    }
    public void Lv1FirstTextPos()
    {
        Pos[0] = Random.Range(-3, 3);
        #region
        if (Pos[0] < 0)
            Pos[0] = Pos[0] + 26;

        firstCode[Pos[0]].text = "" + (int)codeNum[0];
        #endregion
    }

    public void Lv2FirstTextPos()
    {
        Pos[0] = Random.Range(-6, 6);
        #region
        if (Pos[0] < 0)
            Pos[0] = Pos[0] + 26;
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
        #endregion
    }
    public void Lv3FirstTextPos()
    {
        Pos[0] = Random.Range(-9, 9);
        #region
        if (Pos[0] < 0)
            Pos[0] = Pos[0] + 26;
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
        #endregion
    }
    public void Lv4FirstTextPos()
    {
        Pos[0] = Random.Range(-26, 26);
        #region
        if (Pos[0] < 0)
            Pos[0] = Pos[0] + 26;
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
        #endregion
    }
    public void Lv1SecondTextPos()
    {
        Pos[1] = Random.Range(-3, 3);
        #region
        if (Pos[1] < 0)
            Pos[1] = Pos[1] + 22;
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
        #endregion
    }
    public void Lv2SecondTextPos()
    {
        Pos[1] = Random.Range(-5, 5);
        #region
        if (Pos[1] < 0)
            Pos[1] = Pos[1] + 22;

        secondCode[Pos[1]].text = "" + (int)codeNum[1];
        #endregion
    }
    public void Lv3SecondTextPos()
    {
        Pos[1] = Random.Range(-8, 8);
        #region
        if (Pos[1] < 0)
            Pos[1] = Pos[1] + 22;
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
        #endregion
    }
    public void Lv4SecondTextPos()
    {
        Pos[1] = Random.Range(-22, 22);
        #region
        if (Pos[1] < 0)
            Pos[1] = Pos[1] + 22;
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
        #endregion
    }
    public void Lv1ThirdTextPos()
    {
        Pos[2] = Random.Range(-2, 2);
        #region
        if (Pos[2] < 0)
            Pos[2] = Pos[2] + 15;
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
        #endregion
    }
    public void Lv2ThirdTextPos()
    {
        Pos[2] = Random.Range(-3, 3);
        #region
        if (Pos[2] < 0)
            Pos[2] = Pos[2] + 15;
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
        #endregion
    }
    public void Lv3ThirdTextPos()
    {
        Pos[2] = Random.Range(-5, 5);
        #region
        if (Pos[2] < 0)
            Pos[2] = Pos[2] + 15;
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
        #endregion
    }
    public void Lv4ThirdTextPos()
    {
        Pos[2] = Random.Range(-15, 15);
        #region
        if (Pos[2] < 0)
            Pos[2] = Pos[2] + 15;
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
        #endregion
    }
    public void Lv1and2FourthTextPos()
    {
        Pos[3] = Random.Range(-1, 1);
        #region
        if (Pos[3] < 0)
            Pos[3] = Pos[3] + 8;
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
        #endregion
    }
    public void Lv3FourthTextPos()
    {
        Pos[3] = Random.Range(-2, 2);
        #region
        if (Pos[3] < 0)
            Pos[3] = Pos[3] + 8;
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
        #endregion
    }
    public void Lv4FourthTextPos()
    {
        Pos[3] = Random.Range(-8, 8);
        #region
        if (Pos[3] < 0)
            Pos[3] = Pos[3] + 8;
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
        #endregion
    }

    public void MoveSlider()
    {
        preValue = nowValue;
        nowValue = (float)slider.value;
        sliderValue.text = "" + (float)slider.value;

        if (nowValue - preValue > 0)
        {
            if (fourthCheck == false)   //네번째 정답 못맞춤
            {
                if (thirdCheck == false)    //네번째, 세번째 정답 못 맞춤
                {

                    if (secondCheck == false)   //넷,셋,두번째 정답 못 맞춤
                    {
                        if (firstCheck == false)    //아무 비밀번호도 못 맞춤
                        {
                            firstMovePlus();
                        }

                        if (firstCheck == true)     //첫번째 비밀번호만 맞춤
                        {
                            secondMovePlus();
                        }
                    }
                    if (secondCheck == true)    //첫,두번째 비밀번호 맞춤
                    {
                        thirdMovePlus();
                    }
                }
                if (thirdCheck == true) //세번째 까지 맞춤
                {
                    fourthMovePlus();
                }
            }
        }
        else if (nowValue - preValue < 0)
        {
            if (fourthCheck == false)   //네번째 정답 못맞춤
            {
                if (thirdCheck == false)    //네번째, 세번째 정답 못 맞춤
                {

                    if (secondCheck == false)   //넷,셋,두번째 정답 못 맞춤
                    {
                        if (firstCheck == false)    //아무 비밀번호도 못 맞춤
                        {
                            firstMoveMinus();
                        }

                        if (firstCheck == true)     //첫번째 비밀번호만 맞춤
                        {
                            secondMoveMinus();
                        }
                    }
                    if (secondCheck == true)    //첫,두번째 비밀번호 맞춤
                    {
                        thirdMoveMinus();
                    }
                }
                if (thirdCheck == true) //세번째 까지 맞춤
                {
                    fourthMoveMinus();
                }
            }
        }

    }
    public void CheckButton()
    {
        if (fourthCheck == false)
        {
            if (thirdCheck == false)
            {
                if (secondCheck == false)
                {
                    if (firstCheck == false)
                    {
                        CheckFirst();
                    }
                    else
                        CheckSecond();
                }
                else
                    CheckThird();

            }
            else
                CheckFourth();
        }
    }
    public void firstMovePlus()
    {
        SoundManager.instance.Tick();
        firstCode[Pos[0]].text = " ";
        (Pos[0])++;
        if (Pos[0] == 26)
            Pos[0] = 0;
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
    }
    public void firstMoveMinus()
    {
        SoundManager.instance.Tick();
        firstCode[Pos[0]].text = " ";
        (Pos[0])--;
        if (Pos[0] < 0)
            Pos[0] = Pos[0] + 26;
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
    }
    public void secondMovePlus()
    {
        SoundManager.instance.Tick();
        secondCode[Pos[1]].text = " ";
        (Pos[1])++;
        if (Pos[1] == 22)
            Pos[1] = 0;
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
    }
    public void secondMoveMinus()
    {
        SoundManager.instance.Tick();
        secondCode[Pos[1]].text = " ";
        (Pos[1])--;
        if (Pos[1] < 0)
            Pos[1] = Pos[1] + 22;
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
    }
    public void thirdMovePlus()
    {
        SoundManager.instance.Tick();
        thirdCode[Pos[2]].text = " ";
        (Pos[2])++;
        if (Pos[2] == 15)
            Pos[2] = 0;
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
    }
    public void thirdMoveMinus()
    {
        SoundManager.instance.Tick();
        thirdCode[Pos[2]].text = " ";
        (Pos[2])--;
        if (Pos[2] < 0)
            Pos[2] = Pos[2] + 15;
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
    }
    public void fourthMovePlus()
    {
        SoundManager.instance.Tick();
        fourthCode[Pos[3]].text = " ";
        (Pos[3])++;
        if (Pos[3] == 8)
            Pos[3] = 0;
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
    }

    public void fourthMoveMinus()
    {
        SoundManager.instance.Tick();
        fourthCode[Pos[3]].text = " ";
        (Pos[3])--;
        if (Pos[3] < 0)
            Pos[3] = Pos[3] + 8;
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
    }

    public void CheckFirst()
    {
        int NowNum = 0;
        string s = firstCode[0].text;
        bool result = int.TryParse(s, out NowNum);
        //현재 0번 위치에 있는 값이 있어서 result 가 true이면 NowNum에 넣어줌
        if (NowNum == codeNum[0])
        {
            firstCheck = true;
            Debug.Log("첫 번째 정답");
            SoundManager.instance.Success();
            arrow[0].SetActive(false);
            arrow[1].SetActive(true);
            if (level == 1)
                Lv1SecondTextPos();
            else if (level == 2)
                Lv2SecondTextPos();
            else if(level==3)
                Lv3SecondTextPos();
            else if (level == 4)
                Lv4SecondTextPos();
            slider.value = 50;
        }
        if (NowNum != codeNum[0])
        {
            firstCheck = false;
            Debug.Log("첫 번째 틀림");
            redPanel.SetActive(true);
            SoundManager.instance.Cave();
            Invoke("del_red", 1.5f);
        }
    }
    public void CheckSecond()
    {
        int NowNum2 = 0;
        string s2 = secondCode[0].text;
        bool result2 = int.TryParse(s2, out NowNum2);
        if (NowNum2 == codeNum[1])
        {
            secondCheck = true;
            Debug.Log("두 번째 정답");
            SoundManager.instance.Success();
            arrow[1].SetActive(false);
            arrow[2].SetActive(true);
            if (level == 1)
                Lv1ThirdTextPos();
            else if (level == 2)
                Lv2ThirdTextPos();          
            else if (level == 3)
                Lv3ThirdTextPos();          
            else if (level == 4)
                Lv4ThirdTextPos();        
            slider.value = 50;

        }
        if (NowNum2 != codeNum[1])
        {
            secondCheck = false;
            Debug.Log("두 번째 틀림");
            redPanel.SetActive(true);
            SoundManager.instance.Cave();
            Invoke("del_red", 1.5f);
        }
    }
    public void CheckThird()
    {
        int NowNum3 = 0;
        string s3 = thirdCode[0].text;
        bool result3 = int.TryParse(s3, out NowNum3);
        if (NowNum3 == codeNum[2])
        {
            thirdCheck = true;
            Debug.Log("세 번째 정답");
            SoundManager.instance.Success();
            arrow[2].SetActive(false);
            arrow[3].SetActive(true) ;
            if(level==1)
                Lv1and2FourthTextPos();
            else if(level==2)
                Lv1and2FourthTextPos();
            else if (level == 3)
                Lv3FourthTextPos();
            else if (level == 4)
                Lv4FourthTextPos();
            slider.value = 50;
        }
        if (NowNum3 != codeNum[2])
        {
            thirdCheck = false;
            Debug.Log("세 번째 틀림");
            redPanel.SetActive(true);
            SoundManager.instance.Cave();
            Invoke("del_red", 1.5f);
        }
    }
    public void CheckFourth()
    {
        int NowNum4 = 0;
        string s4 = fourthCode[0].text;
        bool result4 = int.TryParse(s4, out NowNum4);
        if (NowNum4 == codeNum[3])
        {
            fourthCheck = true;
            Debug.Log("네 번째 정답");
            SoundManager.instance.OpenDoor();
            slider.value = 50;
        }
        if (NowNum4 != codeNum[3])
        {
            fourthCheck = false;
            Debug.Log("네 번째 틀림");
            redPanel.SetActive(true);
            SoundManager.instance.Cave();
            Invoke("del_red", 1.5f);
        }
    }
    public void GameSuccess()
    {
        if ((firstCheck == true) && (secondCheck == true) && (thirdCheck == true) && (fourthCheck == true))
        {
            Time.timeScale = 0f;    //게임 시간 정지

            if ((1<=level)&&(level<=3))
            {
                resultPanel.SetActive(true);    //결과 패널
                UIManager.instance.printTime(); //소요 시간 출력
            }
            if (level == 4)
            {
                scene[4].SetActive(true);
                Time.timeScale = 1f;
                Invoke("ending", 1.5f);
            }

            Clear();
        }

    }
    public void Clear()
    {
        codeNum.Clear();

        slider.value = 50;

        for(int i=0; i < firstCode.Length; i++)
        {
            firstCode[i].text = " ";
        }
        for (int i = 0; i < secondCode.Length; i++)
        {
            secondCode[i].text = " ";
        }
        for (int i = 0; i < thirdCode.Length; i++)
        {
            thirdCode[i].text = " ";
        }
        for (int i = 0; i < fourthCode.Length; i++)
        {
            fourthCode[i].text = " ";
        }

        codeNum.Clear();
        ShowCode.Clear();

        firstCheck = false;
        secondCheck = false;
        thirdCheck = false;
        fourthCheck = false;

        for(int i=0; i<4; i++)
        {
            arrow[i].SetActive(false);
        }

        level++;
        UIManager.instance.setZero();
    }
    public void ending()
    {
        //SceneChangeManager.instance.Result();
        clearPanel.SetActive(true);
        UIManager.instance.endTime();
        UIManager.instance.EndScore();
    }

    public void dialbuttonClick()
    {
        SoundManager.instance.Tick();
        if (level == 1)
            scene[0].SetActive(false);
        
        if (level == 2)
            scene[1].SetActive(false);
        
        if (level == 3)
            scene[2].SetActive(false);
        
        if (level == 4)
            scene[3].SetActive(false);
        
        GamePlay();
    }

    public void nextButton()
    {
        SoundManager.instance.menu_Click();
        resultPanel.SetActive(false);

        if (level == 2)
        {
            Key.SetActive(false);
            scene[1].SetActive(true);
        }
        if (level == 3)
        {
            Key.SetActive(false);
            scene[2].SetActive(true);
        }
        if (level == 4)
        {
            Key.SetActive(false);
            scene[3].SetActive(true);
        }
        else
        {
            Key.SetActive(false);
            Debug.Log("탈출 성공!");
        }

    }

    public void Ending()
    {
        clearPanel.SetActive(true);
    }
    public void del_result()
    {
        resultPanel.SetActive(false);
    }
    public void del_red()
    {
        redPanel.SetActive(false);
    }
}
