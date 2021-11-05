﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperAttackCollision : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<CharacterStats>().PlayerDamage(2);
        }
    }
}
