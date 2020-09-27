using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ai : MonoBehaviour
{
   public float speed;
   public float distance;
   private bool movingRight = true;
    public float checkRadius;
    public Transform ground_check;
    


    private void Start()
    {
       
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundinfo = Physics2D.Raycast(ground_check.position, Vector2.down, distance);
        if(groundinfo.collider == false) {
            if(movingRight == true) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    void Chill()
    {
        
    }

    void Attack()
    { 
    
    }

    void GoBack()
    { 
    
    }

    void run()
    {

    }












   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ground_check.position, checkRadius); //посмотреть границы объекта checkradius

    }*/
}
