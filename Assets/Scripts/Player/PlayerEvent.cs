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
        Debug.Log("游戏进行中");
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Crash!");
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("触地");

        }
    }*/
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "ci":
                Debug.Log("遇到刺了");
                Die();
                break;
            case "qiang":
                Debug.Log("遇到墙了");
                Die();
                break;
            case "dun":
                Debug.Log("得到护盾了");
                break;
            case "zhuan":
                Debug.Log("遇到转向标了");
                break;
        }
    
    }
    private void Die()
    {
        animator.SetInteger("state", 3);
        controller.speed = 0;
    }
}
