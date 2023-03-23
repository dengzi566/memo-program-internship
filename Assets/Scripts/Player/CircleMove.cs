using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    //设置圆心位置
    public Transform center;
    //设置旋转速度
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
