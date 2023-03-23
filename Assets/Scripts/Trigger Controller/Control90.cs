using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control90 : MonoBehaviour
{
    GameObject obj;
    AngleController angleController;
    public float angle;
    GameObject ci;
    GameObject dun;
    GameObject zhuan;
    GameObject qiang;
    public int i;
    bool change = false;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player");
        Transform transform;
        angleController = obj.GetComponent<AngleController>();
        transform = GameObject.Find("90").transform;
        ci = transform.Find("ci").gameObject;
        dun = transform.Find("dun").gameObject;
        zhuan = transform.Find("zhuan").gameObject;
        qiang = transform.Find("qiang").gameObject;
        i = Random.Range(1, 5);

        switch (i)
        {
            case 1:
                Debug.Log("���ɴ�");
                ci.SetActive(true);
                break;
            case 2:
                Debug.Log("����ǽ");
                qiang.SetActive(true);
                break;
            case 3:
                Debug.Log("����ת���");
                zhuan.SetActive(true);
                break;
            case 4:
                Debug.Log("���ɻ���");
                dun.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        angle = angleController.angle;
        if (angle >= (90 - 10) && angle <= (90 + 10))
        {
            change = true;
            Invoke("chg", 0.8f);
        }


    }
    void chg()
    {
        if (change)
        {
            Debug.Log("���ر任��");
            switch (i)
            {
                case 1:
                    Debug.Log("���ɴ�");
                    ci.SetActive(false);
                    break;
                case 2:
                    Debug.Log("����ǽ");
                    qiang.SetActive(false);
                    break;
                case 3:
                    Debug.Log("����ת���");
                    zhuan.SetActive(false);
                    break;
                case 4:
                    Debug.Log("���ɻ���");
                    dun.SetActive(false);
                    break;
            }
            change = false;

            Invoke("chg2", 0.5f);
        }
    }
    void chg2()
    {
        i = Random.Range(1, 5);
        switch (i)
        {
            case 1:
                Debug.Log("���ɴ�");
                ci.SetActive(true);
                break;
            case 2:
                Debug.Log("����ǽ");
                qiang.SetActive(true);
                break;
            case 3:
                Debug.Log("����ת���");
                zhuan.SetActive(true);
                break;
            case 4:
                Debug.Log("���ɻ���");
                dun.SetActive(true);
                break;
        }

    }
}

