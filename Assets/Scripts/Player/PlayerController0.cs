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
        CoinText.text = "Ŀǰ��ң�" + Globle.coins;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 && IsOnGround)
        {
            Debug.Log("�����ƶ�");
            transform.localScale = new Vector3(2, 2, 2);
            state = 0;
            animator.SetInteger("state", state);
        }
        else if (horizontal < 0 && IsOnGround)
        {
            Debug.Log("�����ƶ�");
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
        //���ر�Ϊ�ܲ�����
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("����");
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
            Debug.Log("�˳���Ϸ");
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        if (collision.tag == "upskill")
        {
            Debug.Log("����ҳ��");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Upskill");
        }
        if (collision.tag == "start")
        {
            Debug.Log("��ʼ��Ϸ");
            //Application.LoadLevel("planet1");
            UnityEngine.SceneManagement.SceneManager.LoadScene("planet1");
        }
    }

}
