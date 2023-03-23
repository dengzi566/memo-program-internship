using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceJump : MonoBehaviour
{
    //设置初始速度大小
    public float speed;
    //设置圆形半径
    public float circleRadius;
    //设置圆心位置
    public Vector3 circleCenter = Vector3.zero;
    //获取刚体组件引用
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //获取刚体组件引用
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果用户按下了空格键，并且人物接触到圆形
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //给刚体设置一个向上的初速度
            rb.velocity = transform.localPosition * speed;

        }

    }
    bool IsGrounded()
    {
        //计算人物与圆心的距离
        float distance = Vector3.Distance(transform.position, circleCenter);
        //如果距离小于等于圆形半径
        if (distance <= circleRadius)
        {
            //返回真值，表示接触到圆形
            return true;

        }
        else
        {
            //返回假值，表示没有接触到圆形
            return false;

        }

    }

}


