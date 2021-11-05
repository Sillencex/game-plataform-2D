using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
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
            collision.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
            collision.transform.GetComponent<CharacterStats>().PlayerDamage(1);
        }
    }
}
