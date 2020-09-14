﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float checkRadius;
    public int extraJumpsValue;
    public Transform groundCheck;
    public float jumpForce;
    public float speed;
    // private float moveInput;

    public LayerMask whatIsGround;
    Animator animator;
    private int exstraJumps;
    private bool facingRight = true;
    private bool isGrounded;
    private Rigidbody2D rb;
    SpriteRenderer sprite;

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (facingRight == false) 
            {
                Flip();
            }

            animator.Play("Run");
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (facingRight == true)
            {
                Flip();
            }
            animator.Play("Run");
          
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.Play("Idle");
        }




    }

    void Flip()
    {
        //метод поворота пеерсонажа, можешь не вникать
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius); //посмотреть границы объекта checkradius

    }

    private void Start()
    {
        exstraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();



}
private void Update()
{ 
    if (isGrounded == true)
    { //проверка на пол под персонажем
        exstraJumps = extraJumpsValue;
    }


    if (Input.GetKeyDown(KeyCode.Space) && exstraJumps > 0) //логика прыжка
    {

        rb.velocity = Vector2.up * jumpForce;
        exstraJumps--;

    }

   

}
}
