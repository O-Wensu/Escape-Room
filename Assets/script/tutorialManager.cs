using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialManager : MonoBehaviour
{
    #region 
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
    public GameObject[] explains;
    private int[] Pos = new int[4];
    public Slider slider;
    public Text sliderValue;
    private float preValue = 50f;
    private float nowValue = 50f;
    private bool firstCheck = false;
    private bool secondCheck = false;
    private bool thirdCheck = false;
    private bool fourthCheck = false;
    public GameObject resultPanel;
    public GameObject retryPanel;
    public GameObject explainPanel;
    public GameObject whitePanel;
    public int i = 0;
    public GameObject _key;
    public GameObject[] Arrow;
    public GameObject tutoScene;
    private int count;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        firstCheck = true;
        secondCheck = true;
        //StartCoroutine("DestroyExplain");
        for (int i = 0; i < 5; i++)
        {
            randNum = Random.Range(0, 99);
            codeNum.Add(randNum);
            ShowCode.Add(randNum);
        }

        ShowCode.RemoveRange(0, 2);

        line = string.Join(" ", ShowCode.ToArray());
        CodeText.text = "암호 : " + line;
        ThirdTextPos();
        LastText.text = "" + (int)codeNum[4];
    }

    void Update()
    {
        suc_scene();
    }

    public void FirstTextPos()
    {
        while (true)
        {
            Pos[0] = Random.Range(0, 4);
            if (Pos[0] != 2)
                break;
            
        }
        Debug.Log(Pos[0] + "번자리");
        firstCode[Pos[0]].text = "" + (int)codeNum[0];
    }

    public void SecondTextPos()
    {
        while (true)
        {
            Pos[1] = Random.Range(0, 4);
            if (Pos[1] != 3)
                break;
            
        }
        Debug.Log(Pos[1]+"번자리");
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
    }

    public void ThirdTextPos()
    {
        while (true)
        {
            Pos[2] = Random.Range(0, 2);
            if (Pos[2] != 2)
                break;
            
        }
        Debug.Log(Pos[2] + "번자리");
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
    }
    public void FourthTextPos()
    {
        while (true)
        {
            Pos[3] = Random.Range(0, 2);
            if (Pos[3] != 1)
                break;
            
        }
        Debug.Log(Pos[3] + "번자리");
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
    }

    public void MoveSlider()
    {
        preValue = nowValue;
        nowValue = (float)slider.value;
        sliderValue.text = "" + (float)slider.value;

        count++;
        if (count < 5)
        {
            return;
        }

        if (count == 5)
        {
            count = 0;
        }
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

        else if (nowValue - preValue < 0)//(0 <= slider.value) && (slider.value <= 50)
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

    public void firstMovePlus()
    {
        if (Pos[0] < 4)
        {
            SoundManager.instance.Tick();
            firstCode[Pos[0]].text = " ";
            (Pos[0])++;
            firstCode[Pos[0]].text = "" + (int)codeNum[0];

        }
        if (Pos[0] == 4)
        {
            firstCode[Pos[0]].text = "" + (int)codeNum[0];
        }

    }

    public void firstMoveMinus()
    {
        if (Pos[0] > 0)
        {
            SoundManager.instance.Tick();
            firstCode[Pos[0]].text = " ";
            (Pos[0])--;
            firstCode[Pos[0]].text = "" + (int)codeNum[0];

        }
        if (Pos[0] == 0)
        {
            firstCode[Pos[0]].text = "" + (int)codeNum[0];
        }
    }

    public void secondMovePlus()
    {
        if (Pos[1] < 4)
        {
            SoundManager.instance.Tick();
            secondCode[Pos[1]].text = " ";
            (Pos[1])++;
            secondCode[Pos[1]].text = "" + (int)codeNum[1];

        }
        if (Pos[1] == 4)
        {
            secondCode[4].text = "" + (int)codeNum[1];
        }
    }

    public void secondMoveMinus()
    {
        if (Pos[1] > 0)
        {
            SoundManager.instance.Tick();
            secondCode[Pos[1]].text = " ";
            (Pos[1])--;
            secondCode[Pos[1]].text = "" + (int)codeNum[1];

        }
        if (Pos[1] == 0)
        {
            secondCode[0].text = "" + (int)codeNum[1];
        }
    }

    public void thirdMovePlus()
    {
        if (Pos[2] < 2)
        {
            SoundManager.instance.Tick();
            thirdCode[Pos[2]].text = " ";
            (Pos[2])++;
            thirdCode[Pos[2]].text = "" + (int)codeNum[2];

        }
        if (Pos[2] == 2)
        {
            thirdCode[2].text = "" + (int)codeNum[2];
        }
    }

    public void thirdMoveMinus()
    {
        if (Pos[2] > 0)
        {
            SoundManager.instance.Tick();
            thirdCode[Pos[2]].text = " ";
            (Pos[2])--;
            thirdCode[Pos[2]].text = "" + (int)codeNum[2];

        }
        if (Pos[2] == 0)
        {
            thirdCode[0].text = "" + (int)codeNum[2];
        }
    }

    public void fourthMovePlus()
    {
        if (Pos[3] < 2)
        {
            SoundManager.instance.Tick();
            fourthCode[Pos[3]].text = " ";
            (Pos[3])++;
            fourthCode[Pos[3]].text = "" + (int)codeNum[3];

        }
        if (Pos[3] == 2)
        {
            fourthCode[2].text = "" + (int)codeNum[3];
        }
    }

    public void fourthMoveMinus()
    {
        if (Pos[3] > 0)
        {
            SoundManager.instance.Tick();
            fourthCode[Pos[3]].text = " ";
            (Pos[3])--;
            fourthCode[Pos[3]].text = "" + (int)codeNum[3];

        }
        if (Pos[3] == 0)
        {
            fourthCode[0].text = "" + (int)codeNum[3];
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

    
    public void CheckFirst()
    {
        int NowNum = 0;
        string s = firstCode[2].text;
        bool result = int.TryParse(s, out NowNum);
        if (NowNum == codeNum[0])
        {
            firstCheck = true;
            Debug.Log("첫 번째 정답");
            SoundManager.instance.Success();
            SecondTextPos();
            //Arrow[0].SetActive(false);
            //Arrow[1].SetActive(true);
            slider.value = 50;
        }
        if (NowNum != codeNum[0])
        {
            firstCheck = false;
            Debug.Log("첫 번째 틀림");
            retryPanel.SetActive(true);
            SoundManager.instance.Cave();
            Invoke("DestroyTry", 2);
        }
    }
    

   
    public void CheckSecond()
    {
        int NowNum2 = 0;
        string s2 = secondCode[2].text;
        bool result2 = int.TryParse(s2, out NowNum2);
        if (NowNum2 == codeNum[1])
        {
            secondCheck = true;
            Debug.Log("두 번째 정답");
            SoundManager.instance.Success();
            ThirdTextPos();
            //Arrow[1].SetActive(false);
            //Arrow[2].SetActive(true);
            slider.value = 50;
        }
        if (NowNum2 != codeNum[1])
        {
            secondCheck = false;
            Debug.Log("두 번째 틀림");
            retryPanel.SetActive(true);
            SoundManager.instance.Cave();
            Invoke("DestroyTry", 2);
        }
    }
    
    public void CheckThird()
    {
        int NowNum3 = 0;
        string s3 = thirdCode[1].text;
        bool result3 = int.TryParse(s3, out NowNum3);
        if (NowNum3 == codeNum[2])
        {
            thirdCheck = true;
            Debug.Log("세 번째 정답");
            SoundManager.instance.Success();
            FourthTextPos();
            //Arrow[2].SetActive(false);
            //Arrow[3].SetActive(true);
            slider.value = 50;
        }
        if (NowNum3 != codeNum[2])
        {
            thirdCheck = false;
            Debug.Log("세 번째 틀림");
            retryPanel.SetActive(true);
            SoundManager.instance.Cave();
            Invoke("DestroyTry", 2);
        }
    }

    public void CheckFourth()
    {
        int NowNum4 = 0;
        string s4 = fourthCode[1].text;
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
            retryPanel.SetActive(true);
            SoundManager.instance.Cave();
            Invoke("DestroyTry", 1f);
        }
    }

    public void suc_scene()
    {
        if ((firstCheck == true) && (secondCheck == true) && (thirdCheck == true) && (fourthCheck == true))
        {
            Time.timeScale = 0f;
            resultPanel.SetActive(true);
            UIManager.instance.printTuToTime();

        }

    }

    public void DestroyTry()
    {
        retryPanel.SetActive(false);
    }

    public void nextExplain()
    {
        if (i == 0)
        {
            explains[i].SetActive(false);
            i++; //i=1
            explains[i].SetActive(true);
        }
        else if (i == 1)
        {
            explains[i].SetActive(false);
            i++; //i=2
            _key.SetActive(true);
            explains[i].SetActive(true);
        }
        else if (i == 2)
        {
            explains[i].SetActive(false);
        }
        else if (i==3)
        {
            explains[i -1].SetActive(false);
            explains[i].SetActive(true);
            i++;
        }
        else if (i == 4)
        {
            explains[i - 1].SetActive(false);
            explains[i].SetActive(true);
        }
        else
            for (int i = 0; i < 5; i++)
            {
                explains[i].SetActive(false);
            }
    }

    public void Des_explain()
    {
        for(int i=0; i<5; i++)
        {
            explains[i].SetActive(false);
        }
        whitePanel.SetActive(false);
    }
    public void stopCount()
    {
        if (i == 2)
            i = 3;
        else
            i = -1;
    }

    public void del_tuto()
    {
        tutoScene.SetActive(false);
    }
}
