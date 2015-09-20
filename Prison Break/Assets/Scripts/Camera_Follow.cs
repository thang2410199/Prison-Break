using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour {

    public Transform player;
    public float limitx;
    public float limit_x;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player = GameObject.Find("player_top").transform;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player = GameObject.Find("player_bottom").transform;
        }
        Vector3 playerpos = player.position;
        Vector3 playerxps = new Vector3(playerpos.x, 0, -10);
        
        if (playerpos.x > limitx)
        {
            playerxps = new Vector3(limitx, 0, -10);
        } else if (playerpos.x < limit_x)
        {
            playerxps = new Vector3(limit_x, 0, -10);
        }
        transform.position = playerxps;


    }
}
