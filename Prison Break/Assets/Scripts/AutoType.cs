using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

//[RequireComponent(typeof(AudioSource))]
public class AutoType : MonoBehaviour
{

    public float letterPause = 0.1f;
    public Text guiText;
    string message;
    public Image bubleChat;

    //public AudioClip sound;
    //AudioSource audio;

    // Use this for initialization
    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    public void SetText(string newText)
    {
        message = newText;
    }

    public void Stop()
    {
        StopCoroutine("TypeText");
        guiText.text = "";
        bubleChat.enabled = false;
    }

    public void Skip(string text = "")
    {
        StopCoroutine("TypeText");
        if (!string.IsNullOrEmpty(text))
            message = text;
        guiText.text = message;
    }

    public void PlayText()
    {
        StopCoroutine("TypeText");
        guiText.text = "";
        bubleChat.enabled = true;
        StartCoroutine("TypeText");
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            guiText.text += letter;

            //if (sound)
            //    audio.PlayOneShot(sound);

            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }

    internal void SetPosition(Vector2 position)
    {
        bubleChat.transform.position = new Vector3(position.x, position.y + Screen.height, bubleChat.transform.position.z);
    }
}
