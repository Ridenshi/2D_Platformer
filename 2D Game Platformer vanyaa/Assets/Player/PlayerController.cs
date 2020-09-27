using System;
using System.Collections;
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

    public Transform punch1;
    public float punch1Radius;


    public float otkatAtaki;
    private float timer;
    private bool readyAttack;

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
        else if (Input.GetKey(KeyCode.Space))
        {

            if (reload())
            {
                animator.Play("Attack");
                timer = 0.0f;
                Debug.Log("Нажатаффффффффф");
            }
            
        }
      /*  else if (Input.GetKey(KeyCode.Space))
        {
            hitEnd();
            animator.Play("Attack");
            Debug.Log("Нажата");
        }*/
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.Play("Idle");
        }

        
         

    }

    bool reload() //это проверка 
    {
        if (timer <= otkatAtaki)
        {
            timer += Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
    }
    void hitEnd()
    {
        Fight2D.Action(punch1.position, punch1Radius, 9, 50, false);       //событие в анимации, чтобы удар был после неё
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


    if (Input.GetKeyDown(KeyCode.W) && exstraJumps > 0) //логика прыжка
    {

        rb.velocity = Vector2.up * jumpForce;
        exstraJumps--;

    }

   

}
}

