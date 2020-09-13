using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_controller : MonoBehaviour
{
    public float speed;
    private GameObject Arrow;
    private Rigidbody2D rb;


    private void Start()
    {
       // rb.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        
            transform.Translate(Vector2.right * speed * Time.deltaTime);
          
        
        
    }
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            
            Stop();
            Destroy(gameObject, 3f);


        }
    }
    private void Stop()
    {

        speed = 0f;
            //rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }
}
