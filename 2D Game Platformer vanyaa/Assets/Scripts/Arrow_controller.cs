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

       

    }
    void Update()
    {
        
            transform.Translate(Vector2.right * speed * Time.deltaTime);
      
    }
   
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            
            Stop();
            Destroy(gameObject, 3f);

        }
        else if (other.gameObject.tag == "Player")
        {
            Stop();
            Destroy(gameObject, 3f);
            GameObject.Find("Character").GetComponent<Player_HP>().AddDamagetoPlayer(-20);
            Debug.Log("В игрока попала стрела и он получил урон : -20");
            GetComponent<Rigidbody2D>().simulated = false;
           

        }
    }
    private void Stop()
    {

        speed = 0f;
        //  rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
       

    }
}
