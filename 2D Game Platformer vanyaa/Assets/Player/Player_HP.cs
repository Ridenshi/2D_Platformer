using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    public float PlayerHP;
    public void AddDamagetoPlayer(float damage)
    {
        PlayerHP += damage;

        if (PlayerHP <= 0)
        {
            PlayerHP = 0;
            Destroy(gameObject);
        }
    }

    

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {
            Debug.Log("смерт");
        }
      //  DestroyObject(GetType.Equals.name.Wall, 2f);
    }*/
}
