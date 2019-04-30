using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public AudioSource Music;
    public AudioClip hoverMusic;
    public AudioClip clickMusic;

    public void HoverSound()
    {
        Music.PlayOneShot(hoverMusic);
    }

    public void clickSound()
    {
        Music.PlayOneShot(clickMusic);
    }
}
