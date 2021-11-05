using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Transform boss;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            boss = collision.transform;
            collision.GetComponent<BossController>().enabled = false;
            collision.transform.parent = transform;
            collision.transform.localPosition = Vector3.zero;
        }
    }

    public void ReleaseBoss()
    {
        boss.GetComponent<BossController>().enabled = true;
        boss.parent = null;
    }
}
