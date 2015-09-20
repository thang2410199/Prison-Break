using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using System.Collections.Generic;

public class DialogBehaviourScript : MonoBehaviour {

    public Text dialogText;
    public static Text StaticDialogText;
    public AutoType typer;
    public static AutoType StaticTyper;
    int currentTextIndex = 0;
    // Use this for initialization
    void Start()
    {
        typer = dialogText.GetComponent<AutoType>();
        StaticDialogText = dialogText;
        StaticTyper = typer;
    }
    
    static List<Dialog> DisplayStrings = new List<Dialog>();


    public static void AddText(params Dialog[] items)
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
            if (touch.phase == TouchPhase.Ended)
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
