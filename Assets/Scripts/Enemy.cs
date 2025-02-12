using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region variable
    [SerializeField] Transform targetDestination; //target player
    [SerializeField] float speed; //speed enemy
    private Animator animator;

    Rigidbody2D rb;
    #endregion
    #region code
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //get Rigibody2d
        animator = GetComponent<Animator>(); //get animator
    }

    private void FixedUpdate()
    {
        Vector2 direction = (targetDestination.position - transform.position).normalized; //follow player
        rb.velocity = direction * speed; //speed
        animator.SetInteger("Enemy", 1); //enemy play animation

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(10, 10, 1); // turn left
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(-10, 10, 1); // turn right
        }

        // if enemy idle change animation to idle
        if (direction == Vector2.zero)
        {
            animator.SetInteger("Enemy", 0); //enemy idle
        }
    }
    #endregion
}
