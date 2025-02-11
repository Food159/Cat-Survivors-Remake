using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination; //ใส่เป้าหมาย
    [SerializeField] float speed; //ตั้งค่าความเร็ว
    private Animator animator;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //รับค่า Rigibody2d
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (targetDestination.position - transform.position).normalized; //ตั้งค่าให้ตามเป้าหมาย
        rb.velocity = direction * speed; //ตั้งค่าความเร็ว
        animator.SetInteger("Enemy", 1);

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(10, 10, 1); // หันไปทางซ้าย
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(-10, 10, 1); // หันไปทางขวา
        }

        // ถ้าตัวละครหยุด ให้เปลี่ยนแอนิเมชั่น
        if (direction == Vector2.zero)
        {
            animator.SetInteger("Enemy", 0);
        }
    }
}
