using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    public Transform spike;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AtackCollider"))
        {
            spike.GetComponent<Animator>().Play("Spike",-1);
            GetComponent<Animator>().Play("Spinning", -1);
        }
    }
}
