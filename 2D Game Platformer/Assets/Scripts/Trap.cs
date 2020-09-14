using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }


     private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {


            Invoke("Fallplatform", 0.15f);
            Destroy(gameObject,2f);
               
           

            
        }
    }
    private void Fallplatform()
    {
        rb.isKinematic = false;
    }

}
