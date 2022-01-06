using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip crash, coin, card, victory;
    static AudioSource audioSource;

    private void Start()
    {
        crash = Resources.Load<AudioClip>("Crash");
        coin = Resources.Load<AudioClip>("Coin");
        card = Resources.Load<AudioClip>("Card");
        victory = Resources.Load<AudioClip>("VictorySound");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySounds(string clip)
    {
        switch(clip)
        {
            case "Crash":
                audioSource.PlayOneShot(crash);
                 break;
            case "Coin":
                audioSource.PlayOneShot(coin);
                break;
            case "Card":
                audioSource.PlayOneShot(card);
                break;
            case "VictorySound":
                audioSource.PlayOneShot(victory);
                break;
        }
           
    }
}
