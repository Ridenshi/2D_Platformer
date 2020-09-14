using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public int HP;
    public int DPS;
  
    void Start()
    {
        
    }


    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {
            Debug.Log("смерт");
        }
      //  DestroyObject(GetType.Equals.name.Wall, 2f);
    }
}
