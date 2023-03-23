using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    private PlayerController controller;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("��Ϸ������");
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Crash!");
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("����");

        }
    }*/
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "ci":
                Debug.Log("��������");
                Die();
                break;
            case "qiang":
                Debug.Log("����ǽ��");
                Die();
                break;
            case "dun":
                Debug.Log("�õ�������");
                break;
            case "zhuan":
                Debug.Log("����ת�����");
                break;
        }
    
    }
    private void Die()
    {
        animator.SetInteger("state", 3);
        controller.speed = 0;
    }
}
