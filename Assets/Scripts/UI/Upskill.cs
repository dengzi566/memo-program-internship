using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upskill : MonoBehaviour
{
    public GameObject jump2;
    public GameObject firstdun;
    public GameObject fallfast;
    public GameObject superball;
    public GameObject tipju;
    public GameObject tipfi;
    public GameObject tipfa;
    public GameObject tipsu;
    public Text CoinText;
    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = "目前金币：" + Globle.coins;
        if (Globle.Jump2)
        {
            jump2.GetComponent<Image>().color = Color.white;
            tipju.SetActive(false);
        }
        if (Globle.FirstDun)
        {
            firstdun.GetComponent<Image>().color = Color.white;
            tipfi.SetActive(false);
        }
        if (Globle.FallFast)
        {
            fallfast.GetComponent<Image>().color = Color.white;
            tipfa.SetActive(false);
        }
        if (Globle.SuperBall)
        {
            superball.GetComponent<Image>().color = Color.white;
            tipsu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockSkill(string tag)
    {
        switch (tag)
        {
            case "Jump2":
                if ((!Globle.Jump2) && Globle.coins >= 100) { 
                    jump2.GetComponent<Image>().color = Color.white;
                    tipju.SetActive(false);
                    Globle.coins -= 100;
                    Globle.Jump2 = true;
                }
                break;
            case "FirstDun":
                if ((!Globle.FirstDun) && Globle.coins >= 50)
                {
                    firstdun.GetComponent<Image>().color = Color.white;
                    tipfi.SetActive(false);
                    Globle.coins -= 50;
                    Globle.FirstDun = true;
                }
                break;
            case "FallFast":
                if ((!Globle.FallFast) && Globle.coins >= 100)
                {
                    fallfast.GetComponent<Image>().color = Color.white;
                    tipfa.SetActive(false);
                    Globle.coins -= 100;
                    Globle.FallFast = true;
                }
                break;
            case "SuperBall":
                if ((!Globle.FirstDun) && Globle.coins >= 100)
                {
                    superball.GetComponent<Image>().color = Color.white;
                    tipsu.SetActive(false);
                    Globle.coins -= 100;
                    Globle.SuperBall = true;
                }
                break;
        }
        CoinText.text = "目前金币：" + Globle.coins;
    }
    public void BackToMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Scene");

    }
}
