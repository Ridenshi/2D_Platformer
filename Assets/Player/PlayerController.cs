using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
public float jumpForce;
private float moveInput;

private Rigidbody2D rb;
private bool facingRight = true;
private bool isGrounded;
public Transform groundCheck;
public float checkRadius;
public LayerMask whatIsGround;

private int exstraJumps;
    public int extraJumpsValue;
 
private void Start()
{
    exstraJumps = extraJumpsValue;
    rb = GetComponent<Rigidbody2D>();

}
private void FixedUpdate()
{

    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


    moveInput = Input.GetAxis("Horizontal"); //Ходьба
    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


    if (facingRight == false && moveInput > 0) //поворот лица персонажа
    {
        Flip();
    }
    else if (facingRight == true && moveInput < 0)
    {
        Flip();
    }

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

     //   transform.position = new Vector3(
         //   Mathf.Clamp(transform.position.x, leftlimit, rightlimit),
         //   Mathf.Clamp(transform.position.y, botlimit, uplimit),
          //  transform.position.z
         //   );


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




}

