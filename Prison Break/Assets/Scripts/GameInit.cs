using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameInit : MonoBehaviour
{
    public static EventManager EventManager;
    public static GameDataContext Context = new GameDataContext();
    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(1080 / 2, 1920 / 2, false);
        EventManager = new EventManager();
        EventManager.InitEvents();
        EventManager.InvokeNextEvent();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
