using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_shoot_block : MonoBehaviour
{
    public float TimeForShoot;
    private float TimeShoot;
    public float spawnX;
    public float spawnY;
    public GameObject Arrow;

    void Start()
    {
        TimeShoot = TimeForShoot;
        
    
    }
   
    void Update()
    {
        TimeShoot -= 1f * Time.deltaTime;
        if (TimeShoot <=0)
        {
            Shoot();
            TimeShoot = TimeForShoot;
        }
    }
    private void Shoot() 
    {

        Instantiate(Arrow, new Vector3(spawnX, spawnY, 0), Quaternion.identity);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue; //прорисовка границ камеры
        Gizmos.DrawWireCube(new Vector2(spawnX, spawnY), new Vector3(1, 1, 1));
      
    }
}
