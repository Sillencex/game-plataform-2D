using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void playSound()
    {
        audioSource.PlayOneShot(clip);
    }
}
