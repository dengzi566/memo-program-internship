using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGravity : MonoBehaviour
{

    //��ȡ�������
    public Rigidbody2D rb;
    //����Բ��λ��
    public Transform center;
    //��������ǿ��
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //���������Բ��֮��ķ���
        Vector2 direction = center.position - transform.position;
        //���������Բ��֮��ľ���
        float distance = direction.magnitude;
        //����������С�����Ը��ݾ������˥������ǿ
        float force = gravity/ (distance * distance);
        //������ʩ��һ�����ŷ������
        rb.AddForce(direction.normalized * force);

    }
}
