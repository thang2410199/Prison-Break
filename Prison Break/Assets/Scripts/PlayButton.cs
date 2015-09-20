using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayButton : MonoBehaviour {

	public Button playButton;

	// Use this for initialization
	void Start () {
        playButton.onClick.AddListener(StartPlay);
    }

    private void StartPlay()
    {
        Application.LoadLevel("Prison_Scene");
        
    }

    // Update is called once per frame
    void Update () {
    }

   
}
