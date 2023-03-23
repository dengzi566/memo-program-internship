using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceJump : MonoBehaviour
{
    //���ó�ʼ�ٶȴ�С
    public float speed;
    //����Բ�ΰ뾶
    public float circleRadius;
    //����Բ��λ��
    public Vector3 circleCenter = Vector3.zero;
    //��ȡ�����������
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //��ȡ�����������
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //����û������˿ո������������Ӵ���Բ��
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //����������һ�����ϵĳ��ٶ�
            rb.velocity = transform.localPosition * speed;

        }

    }
    bool IsGrounded()
    {
        //����������Բ�ĵľ���
        float distance = Vector3.Distance(transform.position, circleCenter);
        //�������С�ڵ���Բ�ΰ뾶
        if (distance <= circleRadius)
        {
            //������ֵ����ʾ�Ӵ���Բ��
            return true;

        }
        else
        {
            //���ؼ�ֵ����ʾû�нӴ���Բ��
            return false;

        }

    }

}


