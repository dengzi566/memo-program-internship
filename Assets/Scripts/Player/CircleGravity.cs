using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGravity : MonoBehaviour
{

    //获取刚体组件
    public Rigidbody2D rb;
    //设置圆心位置
    public Transform center;
    //设置重力强度
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //计算人物和圆心之间的方向
        Vector2 direction = center.position - transform.position;
        //计算人物和圆心之间的距离
        float distance = direction.magnitude;
        //计算重力大小，可以根据距离进行衰减或增强
        float force = gravity/ (distance * distance);
        //给人物施加一个沿着方向的力
        rb.AddForce(direction.normalized * force);

    }
}
