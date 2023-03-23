using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController0 : MonoBehaviour
{
    Rigidbody2D rb;

    private Animator animator;

    public float speed;

    public int state;

    bool IsOnGround;

    public Text CoinText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        CoinText.text = "目前金币：" + Globle.coins;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 && IsOnGround)
        {
            Debug.Log("向右移动");
            transform.localScale = new Vector3(2, 2, 2);
            state = 0;
            animator.SetInteger("state", state);
        }
        else if (horizontal < 0 && IsOnGround)
        {
            Debug.Log("向左移动");
            transform.localScale = new Vector3(-2, 2, 2);
            state = 0;
            animator.SetInteger("state", state);
        }
        else if(IsOnGround)
        {
            state = 4;
            animator.SetInteger("state", state);
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))

        {
            IsOnGround = false;
            rb.velocity = new Vector2(rb.velocity.x, speed);
            state = 1;
            animator.SetInteger("state", state);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Crash!");
        //触地变为跑步动画
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("触地");
            animator.SetInteger("state", 4);
            IsOnGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            IsOnGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "exit")
        {
            Debug.Log("退出游戏");
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        if (collision.tag == "upskill")
        {
            Debug.Log("升级页面");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Upskill");
        }
        if (collision.tag == "start")
        {
            Debug.Log("开始游戏");
            //Application.LoadLevel("planet1");
            UnityEngine.SceneManagement.SceneManager.LoadScene("planet1");
        }
    }

}
