using UnityEngine;
using System.Collections;
using System.Linq;
using Assets.Scripts;

public class Moving : MonoBehaviour
{

    public GameObject[] rb;
    public GameObject PlayerTop, PlayerBottom, CurrentPlayer;
    public double limitx;
    public double limit_x;


    // Use this for initialization
    void Start()
    {
        rb = GameObject.FindGameObjectsWithTag("Player");

        PlayerTop = rb.Where(p => p.name == "player_top").FirstOrDefault();
        PlayerBottom = rb.Where(p => p.name == "player_bottom").FirstOrDefault();
        CurrentPlayer = PlayerTop;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (EventManager.State == GameState.InEvent)
            return;
        if (Input.GetKey(KeyCode.UpArrow)) {
            //rb.velocity = Vector2.zero;
            CurrentPlayer = PlayerTop;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
           
            //rb.velocity = Vector2.zero;
            CurrentPlayer = PlayerBottom;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        if ((CurrentPlayer.transform.position.x < limitx && moveHorizontal > 0) || (CurrentPlayer.transform.position.x > limit_x && moveHorizontal < 0))
        {
            Vector3 movement = new Vector3(moveHorizontal / 10, 0.0f, 0f);
            CurrentPlayer.transform.position += movement;
        }
        //rb.velocity = Vector3.zero;


    }

}
