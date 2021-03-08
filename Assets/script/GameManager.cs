using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region
    private int startLv ;
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
    private int plusN;
    public GameObject chose_level;
    public float SliderMinValue;
    public float SliderMaxValue;
    int count;
    int angle;
    public GameObject origin;
    public float num1;
    #endregion

    public static GameManager instance;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        Slider_minmax();
        angle = 12;
        SliderMinValue = 180;
        SliderMaxValue = 180;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        UIManager.instance.setZero();
    }
    void Update()
    {
        GameSuccess();
        Slider_minmax();

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
            Debug.Log("난이도 : "+startLv);
            if (startLv == 1)
                Lv1ThirdTextPos();
            else if (startLv == 2)
                Lv2ThirdTextPos();
            else if (startLv == 3)
                Lv3ThirdTextPos();
            else if (startLv == 4)
                Lv4ThirdTextPos();
            LastText.text = "" + (int)codeNum[4];
        }
        else if (level == 2)
        {
            firstCheck = true;
            dial[1].SetActive(true);
            arrow[1].SetActive(true);
            if (startLv == 1)
                Lv1SecondTextPos();
            else if (startLv == 2)
                Lv2SecondTextPos();
            else if (startLv == 3)
                Lv3SecondTextPos();
            else if (startLv == 4)
                Lv4SecondTextPos();
            LastText.text = "" + (int)codeNum[4];
        }
        else if (level == 3)
        {
            dial[0].SetActive(true);
            arrow[0].SetActive(true);
            if (startLv == 1)
                Lv1FirstTextPos();
            else if (startLv == 2)
                Lv2FirstTextPos(); 
            else if (startLv == 3)
                Lv3FirstTextPos();
            else if (startLv == 4)
                Lv4FirstTextPos();
            LastText.text = "" + (int)codeNum[4];
        }
        else if (level == 4)
        {
            arrow[0].SetActive(true);
            if (startLv == 1)
                Lv1FirstTextPos();
            else if (startLv == 2)
                Lv2FirstTextPos();
            else if (startLv == 3)
                Lv3FirstTextPos();
            else if (startLv == 4)
                Lv4FirstTextPos();
            LastText.text = "" + (int)codeNum[4];
        }
    }
    private void Lv1FirstTextPos()
    {
        Debug.Log("Lv1FirstTextPos");
        while (true)
        {
            Pos[0] = Random.Range(-3, 3);
            if (Pos[0] == 0)
            {
                Debug.Log("0 다시 돌림");
                continue;
            }
            else
                break;
        }
        #region
        if (Pos[0] < 0)
            Pos[0] = Pos[0] + 26;
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
        #endregion
    }

    private void Lv2FirstTextPos()
    {
        Debug.Log("Lv2FirstTextPos");
        while (true)
        {
            Pos[0] = Random.Range(-6, 6);
            if (Pos[0] == 0)
            {
                Debug.Log("0 다시 돌림");
                continue;
            }
            else
                break;
        }
        #region
        if (Pos[0] < 0)
            Pos[0] = Pos[0] + 26;
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
        #endregion
    }
    private void Lv3FirstTextPos()
    {
        Debug.Log("Lv3FirstTextPos");
        #region
        Pos[0] = Random.Range(7, 19);
        Debug.Log("밑쪽만 나옴");
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
        #endregion
    }
    private void Lv4FirstTextPos()
    {
        Debug.Log("Lv4FirstTextPos");
        #region
        Pos[0] = Random.Range(10, 16);
        //Pos[0] = 0;
        Debug.Log("밑쪽만 나옴");
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
        #endregion
    }
    
    private void Lv1SecondTextPos()
    {
        Debug.Log("Lv1SecondTextPos");
        while (true)
        {
            Pos[1] = Random.Range(-3, 3);
            if (Pos[1] == 0)
            {
                Debug.Log("0 다시 돌림");
                continue;
            }
            else
                break;
        }
        #region
        if (Pos[1] < 0)
            Pos[1] = Pos[1] + 22;
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
        #endregion
    }
    private void Lv2SecondTextPos()
    {
        Debug.Log("Lv2SecondTextPos");
        while (true)
        {
            Pos[1] = Random.Range(-5, 5);
            if (Pos[1] == 0)
            {
                Debug.Log("0 다시 돌림");
                continue;
            }
            else
                break;
        }
        #region
        if (Pos[1] < 0)
            Pos[1] = Pos[1] + 22;
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
        #endregion
    }
    private void Lv3SecondTextPos()
    {
        Debug.Log("Lv3SecondTextPos");
        #region
        Pos[1] = Random.Range(6, 12);
        Debug.Log("밑쪽만 나옴");
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
        #endregion
    }
    private void Lv4SecondTextPos()
    {
        Debug.Log("Lv4SecondTextPos");
        #region
        Pos[1] = Random.Range(8, 15);
        Debug.Log("밑쪽만 나옴");
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
        #endregion
    }
    private void Lv1ThirdTextPos()
    {
        Debug.Log("Lv1ThirdTextPos");
        while (true)
        {
            Pos[2] = Random.Range(-2, 2);
            if (Pos[2] == 0)
            {
                Debug.Log("0 다시 돌림");
                continue;
            }
            else
                break;
        }
        #region
        if (Pos[2] < 0)
            Pos[2] = Pos[2] + 15;
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
        #endregion
    }
    private void Lv2ThirdTextPos()
    {
        Debug.Log("Lv2ThirdTextPos");
        while (true)
        {
            Pos[2] = Random.Range(-3, 3);
            if (Pos[2] == 0)
            {
                Debug.Log("0 다시 돌림");
                continue;
            }
            else
                break;
        }
        #region
        if (Pos[2] < 0)
            Pos[2] = Pos[2] + 15;
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
        #endregion
    }
    private void Lv3ThirdTextPos()
    {
        Debug.Log("Lv3ThirdTextPos");
        #region
        Pos[2] = Random.Range(4, 11);
        Debug.Log("밑쪽만 나옴");
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
        #endregion
    }
    private void Lv4ThirdTextPos()
    {
        Debug.Log("Lv4ThirdTextPos");
        #region
        Pos[2] = Random.Range(6, 9);
        Debug.Log("밑쪽만 나옴");
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
        #endregion
    }
    private void Lv1and2FourthTextPos()
    {
        Debug.Log("Lv1and2FourthTextPos");
        while (true)
        {
            Pos[3] = Random.Range(-1, 1);
            if (Pos[3] == 0)
            {
                Debug.Log("0 다시 돌림");
                continue;
            }
            else
                break;
        }
        #region

        if (Pos[3] < 0)
            Pos[3] = Pos[3] + 8;
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
        #endregion
    }
    private void Lv3FourthTextPos()
    {
        Debug.Log("Lv3FourthTextPos");
        #region
        Pos[3] = Random.Range(2, 6);
        Debug.Log("밑쪽만 나옴");
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
        #endregion
    }
    private void Lv4FourthTextPos()
    {
        Debug.Log("Lv4FourthTextPos");
        #region
        Pos[3] = Random.Range(3,5);
        Debug.Log("밑쪽만 나옴");
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
        #endregion
    }

    public void MoveSlider()
    {
        preValue = nowValue;
        nowValue = (float)slider.value;
        sliderValue.text = "" + (float)slider.value;

        count++;
        if (count < angle)
        {
            return;
        }

        if (count == angle)
        {
            count = 0;
        }

        if (nowValue - preValue >0)
        {
            if (fourthCheck == false)   //네번째 정답 못맞춤
            {
                if (thirdCheck == false)    //네번째, 세번째 정답 못 맞춤
                {

                    if (secondCheck == false)   //넷,셋,두번째 정답 못 맞춤
                    {
                        if (firstCheck == false)    //아무 비밀번호도 못 맞춤
                        {

                            angle = 6;
                            firstMovePlus();
                        }

                        if (firstCheck == true)     //첫번째 비밀번호만 맞춤
                        {
                            angle = 8;
                            secondMovePlus();
                        }
                    }
                    if (secondCheck == true)    //첫,두번째 비밀번호 맞춤
                    {
                        angle = 12;
                        thirdMovePlus();
                    }
                }
                if (thirdCheck == true) //세번째 까지 맞춤
                {
                    angle = 22;
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
                            angle = 6;
                            firstMoveMinus();
                        }

                        if (firstCheck == true)     //첫번째 비밀번호만 맞춤
                        {
                            angle = 8;
                            secondMoveMinus();
                        }
                    }
                    if (secondCheck == true)    //첫,두번째 비밀번호 맞춤
                    {
                        angle = 12;
                        thirdMoveMinus();
                    }
                }
                if (thirdCheck == true) //세번째 까지 맞춤
                {
                    angle = 22;
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
    private void fourthMovePlus()
    {
        SoundManager.instance.Tick();
        fourthCode[Pos[3]].text = " ";
        (Pos[3])++;
        if (Pos[3] == 8)
            Pos[3] = 0;
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
    }

    private void fourthMoveMinus()
    {
        SoundManager.instance.Tick();
        fourthCode[Pos[3]].text = " ";
        (Pos[3])--;
        if (Pos[3] < 0)
            Pos[3] = Pos[3] + 8;
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
    }

    private void CheckFirst()
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
            if (startLv == 1)
                Lv1SecondTextPos();
            if (startLv == 2)
                Lv2SecondTextPos();
            if (startLv == 3)
                Lv3SecondTextPos();
            if (startLv == 4)
                Lv4SecondTextPos();
            slider.value = 180;
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
    private void CheckSecond()
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
            if (startLv == 1)
                Lv1ThirdTextPos();
            if (startLv == 2)
                Lv2ThirdTextPos();
            if (startLv == 3)
                Lv3ThirdTextPos();
            if (startLv == 4)
                Lv4ThirdTextPos();
            slider.value = 180;
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
    private void CheckThird()
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
            if ((startLv == 1)||(startLv == 2))
                Lv1and2FourthTextPos();
            if (startLv == 3)
                Lv3FourthTextPos();
            if (startLv == 4)
                Lv4FourthTextPos();
            slider.value = 180;
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
    private void CheckFourth()
    {
        int NowNum4 = 0;
        string s4 = fourthCode[0].text;
        bool result4 = int.TryParse(s4, out NowNum4);
        if (NowNum4 == codeNum[3])
        {
            fourthCheck = true;
            Debug.Log("네 번째 정답");
            SoundManager.instance.OpenDoor();
            slider.value = 180;
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
    private void GameSuccess()
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
    private void Clear()
    {
        codeNum.Clear();
        slider.value = 180;

        for (int i=0; i < firstCode.Length; i++)
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
        clearPanel.SetActive(true);
        UIManager.instance.endTime();
        Fill_();
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
    public void startLv1()
    {
        SoundManager.instance.menu_Click();
        startLv = 1;
    }
    public void startLv2()
    {
        SoundManager.instance.menu_Click();
        startLv = 2;
    }
    public void startLv3()
    {
        SoundManager.instance.menu_Click();
        startLv = 3;
    }
    public void startLv4()
    {
        SoundManager.instance.menu_Click();
        startLv = 4;
    }
    public void del_choice()
    {
        chose_level.SetActive(false);
    }
    public void Slider_minmax()
    {
        if (slider.value < SliderMinValue)
            SliderMinValue = slider.value;
        if (slider.value > SliderMaxValue)
            SliderMaxValue = slider.value;
    }
    public void Fill_()
    {
        num1 = (float)((GameManager.instance.SliderMaxValue - GameManager.instance.SliderMinValue) * ((double)1 / (double)360));
        origin.transform.GetComponent<Image>().fillAmount = num1;
        Debug.Log(num1);

        float Rotate = (float)((180 - GameManager.instance.SliderMinValue));
        origin.transform.rotation = Quaternion.Euler(0, 0, Mathf.Abs(Rotate)); // Mathf.Abs : 절대값
    }
}
