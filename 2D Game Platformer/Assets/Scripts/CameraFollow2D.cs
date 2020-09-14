using UnityEngine;

public class CameraFollow2D : MonoBehaviour {

    public GameObject player;

    [SerializeField]
    public float leftlimit;
    [SerializeField]
    public float rightlimit;
    [SerializeField]
    public float uplimit;
    [SerializeField]
    public float botlimit;
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f); //границы камеры
           transform.position = new Vector3
            (
           Mathf.Clamp(transform.position.x,  leftlimit,rightlimit),
           Mathf.Clamp(transform.position.y,  botlimit,uplimit),
          transform.position.z
           );

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black; //прорисовка границ камеры
        Gizmos.DrawLine(new Vector2(leftlimit, uplimit), new Vector2(rightlimit, uplimit));
        Gizmos.DrawLine(new Vector2(leftlimit, botlimit), new Vector2(rightlimit, botlimit));
        Gizmos.DrawLine(new Vector2(leftlimit, uplimit), new Vector2(leftlimit, botlimit));
        Gizmos.DrawLine(new Vector2(rightlimit, uplimit), new Vector2(rightlimit, botlimit));
    }
}