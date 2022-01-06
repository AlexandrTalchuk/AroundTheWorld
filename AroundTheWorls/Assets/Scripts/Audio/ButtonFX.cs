using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip ClickFX;

    public void ClickSound()
    {
        myFX.PlayOneShot(ClickFX);
    }
}
