using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int state = 0;

    private bool HaveDun;
    //设置圆心位置
    public Transform center;
    //设置旋转速度
    public  float speed;

    public float jumpspeed=10f;

    public float circleRadius;

    public Vector3 circleCenter = Vector3.zero;

    private Rigidbody2D rb;

    private Animator animator;

    private CircleCollider2D cld;

    public float timer;

    public Text timetext;

    public Text statistics;

    public GameObject die;

    public GameObject toplanet2;

    private bool isDie = false;

    private int jumpcount ;

    private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        gravity = GetComponent<CircleGravity>().gravity;
        //获取组件引用
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cld = GetComponent<CircleCollider2D>();
        timer = 0;
        if (Globle.FirstDun)
        {
            GetComponent<Renderer>().material.color = Color.green;
            HaveDun = true;
        }
        if (Globle.Jump2)
            jumpcount = 2;
        else
            jumpcount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("计时器：" + (int)timer);
        timetext.text = ""+(int)timer;
        transform.RotateAround(center.position, Vector3.back, speed * Time.deltaTime);
        //跳跃
        if (Input.GetKeyDown(KeyCode.Space)&&jumpcount>0)// && IsGrounded()&&(state!=2)
        {
            GetComponent<CircleGravity>().gravity = gravity;
            if (Globle.Jump2)
            {
                if (Globle.SuperBall)
                {
                    Jump();
                }
                else if (state != 2)
                {
                    Jump();
                }
            }
            else if(IsGrounded())
            {
                if (Globle.SuperBall)
                {
                    Jump();
                }
                else if(state != 2)
                {
                    Jump();
                }
            }
            
        }
        //按下S键时
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (IsGrounded())
            {
                Roll();
            }
            else
            {
                if (Globle.SuperBall)
                {
                    Roll();
                }
                if (Globle.FallFast)
                {
                    GetComponent<CircleGravity>().gravity *= 5;
                }
            }
        }
        //抬起S键时
        if (Input.GetKeyUp (KeyCode.S))
        {
            if (IsGrounded())
            {
                Run(); 
            }
            else
            {
                //恢复跳跃形态
                state = 1;
                animator.SetInteger("state", state);
                cld.offset = new Vector2(0, 0.2f);
                cld.radius = 0.4f;
            }
        }
        if (timer >= 10&&timer<=15)
        {
            toplanet2.SetActive(true);
        }
    }
    //判断是否接触地面
    bool IsGrounded()
    {
        float distance = Vector3.Distance(transform.position, circleCenter);
        if (distance <= circleRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //从天空接触地面时
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //触地变为跑步动画
        if (collision.gameObject.tag == "ground")
        {
            GetComponent<CircleGravity>().gravity = gravity;//恢复正常重力
            Debug.Log("触地");
            jumpcount = Globle.Jump2 ? 2 : 1;
            if (state!=2)
            {
            Run();
            state = 0;
            animator.SetInteger("state", state);
            }
        }
    }
    //遭遇机关
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "ci":
                Debug.Log("遇到刺了");
                if (HaveDun)
                {
                    HaveDun = false;
                    GetComponent<Renderer>().material.color = Color.white;
                }
                else
                    Die();
                break;
            case "qiang":
                Debug.Log("遇到墙了");
                if (HaveDun)
                {
                    HaveDun = false;
                    GetComponent<Renderer>().material.color = Color.white;
                }
                else
                    Die();
                break;
            case "dun":
                Debug.Log("得到护盾了");
                GetComponent<Renderer>().material.color = Color.green;
                HaveDun = true;
                break;
            case "zhuan":
                Debug.Log("遇到转向标了");
                speed = -speed;
                if(transform.localScale== new Vector3(1, 1, 1))
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case "Toplanet2":
                UnityEngine.SceneManagement.SceneManager.LoadScene("planet2");
                break;
        }

    }
    //死亡
    private void Die()
    {
        if (!isDie) {
            state = 3;
        animator.SetInteger("state", state);
        speed = 0;
        int Duration = (int)timer;
        timetext.gameObject.SetActive(false);
        statistics.text = "坚持时间: " + Duration + "s    爆金币: " + 5 * Duration;
            Globle.coins += 5 * Duration;
        die.SetActive(true);
        isDie = true;
        }
    }
    public void BackToMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Scene");

    }
    //变成跳跃状态
    private void Jump()
    {
        rb.velocity = transform.localPosition.normalized * jumpspeed * (Screen.width / 1920f);

        //rb.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);


        //rb.AddForce(transform.localPosition.normalized * jumpspeed, ForceMode2D.Impulse);
        if (!Globle.SuperBall)
        {
            state = 1;
            animator.SetInteger("state", state);
        }
        jumpcount--;
    }
    //变为滚动状态
    private void Roll()
    {
        state = 2;
        animator.SetInteger("state", state);
        cld.offset = new Vector2(0, 0);
        cld.radius = 0.2f;
    }
    //变成跑步状态
    private void Run()
    {
        cld.offset = new Vector2(0, 0.2f);
        cld.radius = 0.4f;
        state = 0;
        animator.SetInteger("state", state);
    }
}


