using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    //����Բ��λ��
    public Transform center;
    //������ת�ٶ�
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position, Vector3.back, speed * Time.deltaTime);

    }
}
