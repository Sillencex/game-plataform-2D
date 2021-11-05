using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    Transform Player;
    public Transform skin;

    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);

            skin.GetComponent<Animator>().Play("Stuck", -1);

            collision.transform.position = transform.position;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().SetBool("Run", false);
            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().Play("Idle", -1);

            GetComponent<BoxCollider2D>().enabled = false;

            Player = collision.transform;

            collision.GetComponent<CharacterStats>().PlayerDamage(1);
            

            collision.GetComponent<PlayerController>().enabled = false;

            Invoke("ReleasePlayer", 2);
            Invoke("ResetTrap", 10);
        }
    }

    void ReleasePlayer()
    {
        Player.GetComponent<PlayerController>().enabled = true;
    }

    void ResetTrap()
    {
     GetComponent<BoxCollider>().enabled = true;
        skin.GetComponent<Animator>().Play("UnStuck", -1);
    }
}
