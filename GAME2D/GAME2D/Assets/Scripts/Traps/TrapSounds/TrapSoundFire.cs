using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}
