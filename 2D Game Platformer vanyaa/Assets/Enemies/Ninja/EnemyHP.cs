using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  EnemyHP: MonoBehaviour
{
    public float HP = 100;

    public void AddDamage(float damage)
    {
        HP += damage;

        if (HP <= 0)
        {
            HP = 0;
            Destroy(gameObject); 
        }
    }
}
