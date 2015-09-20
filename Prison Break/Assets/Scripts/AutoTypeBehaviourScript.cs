using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Assets.Scripts;

public class AutoTypeBehaviourScript : MonoBehaviour
{

    public Text systemText;
    public AutoType typer;
    public static AutoType StaticTyper;
    int currentTextIndex = 0;
    // Use this for initialization
    void Start()
    {
        typer = systemText.GetComponent<AutoType>();
        StaticTyper = typer;
    }

    DisplayString InitText;
    static List<DisplayString> DisplayStrings = new List<DisplayString>();


    public static void AddText(params DisplayString[] items)
    {
        DisplayStrings.AddRange(items);
    }


    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            var keyA = Input.GetKeyUp(KeyCode.Z);
            if (keyA)
            {
                foreach (var item in DisplayStrings)
                {
                    if (item.State != DisplayStringState.Ended)
                    {
                        item.Continue(ref typer);
                        break;
                    }
                    else
                    {
                        if (item.IsFinal)
                            EventManager.InvokeComplete();
                    }
                }
            }
        }
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Ended)
            {
                foreach (var item in DisplayStrings)
                {
                    if (item.State != DisplayStringState.Ended)
                    {
                        item.Continue(ref typer);
                    }
                }
                
            }
        }

    }
}
