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
    private int randNum;
    private string line;
    public Text[] firstCode;
    public Text[] secondCode;
    public Text[] thirdCode;
    public Text[] fourthCode;
    public Text LastText;
    private int[] Pos= new int[4];
    public Slider slider;
    public Text sliderValue;
    private bool firstCheck=false;
    private bool secondCheck=false;
    private bool thirdCheck=false;
    private bool fourthCheck=false;
    public GameObject resultPanel;
    public GameObject retryPanel;
    public GameObject explainPanel;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        //Invoke("DestroyExplain", 1);
        StartCoroutine("DestroyExplain");
        for (int i=0; i < 5; i++)
        {
            randNum = Random.Range(0, 99);
            codeNum.Add(randNum);
        }
        line = string.Join(" ", codeNum.ToArray());
        CodeText.text = "암호 : "+ line;
        FirstTextPos();
        SecondTextPos();
        ThirdTextPos();
        FourthTextPos();
        LastText.text = "" + (int)codeNum[4];
    }

    void Update()
    {
        suc_scene();
    }

    IEnumerator DestroyExplain()
    {
        yield return new WaitForSeconds(2.0f);
        explainPanel.SetActive(false);
    }
 
    public void FirstTextPos()
    {
        Pos[0] = Random.Range(0, 4);
        firstCode[Pos[0]].text = ""+(int)codeNum[0];
    }
    
    public void SecondTextPos()
    {
        Pos[1]= Random.Range(0, 3);
        secondCode[Pos[1]].text = "" + (int)codeNum[1];
    }

    public void ThirdTextPos()
    {
        Pos[2] = Random.Range(0, 2);
        thirdCode[Pos[2]].text = "" + (int)codeNum[2];
    }
    public void FourthTextPos()
    {
        Pos[3] = Random.Range(0, 1);
        fourthCode[Pos[3]].text = "" + (int)codeNum[3];
    }

    public void MoveSlider()
    {
        sliderValue.text = ""+(float)slider.value;
        if ((50 <= slider.value) && (slider.value <= 100))
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

        else if ((0 <= slider.value) && (slider.value <= 50))
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
        }
        if (NowNum4 != codeNum[3])
        {
            fourthCheck = false;
            Debug.Log("네 번째 틀림");
            retryPanel.SetActive(true);
            SoundManager.instance.Cave();
            Invoke("DestroyTry", 2);
        }
    }

    public void suc_scene()
    {
        if ((firstCheck == true) && (secondCheck == true) && (thirdCheck == true) && (fourthCheck == true))
        {
            Time.timeScale = 0f;
            resultPanel.SetActive(true);
            UIManager.instance.printTime();
        }

    }

    public void DestroyTry()
    {
        retryPanel.SetActive(false);
    }



}
