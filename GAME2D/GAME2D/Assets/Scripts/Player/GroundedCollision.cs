using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip groundedSound;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("grounded"))
        {
            audioSource.PlayOneShot(groundedSound);
        }

    }
}
