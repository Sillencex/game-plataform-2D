using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public Transform Player;

    public float attackTime;

    void Start()
    {
        attackTime = 0;
    }

    void Update()
    {
        if(GetComponent<CharacterStats>().life <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 10;
            this.enabled = false;
        }
        if (Vector2.Distance(transform.position, Player.position) > 0.1f)
        {
            attackTime = 0;
            transform.position = Vector2.MoveTowards(transform.position, Player.position, 2f * Time.deltaTime);
        }
        else
        {
            attackTime = attackTime + Time.deltaTime;
            if(attackTime >= 1)
            {
                attackTime = 0;
                Player.GetComponent<CharacterStats>().PlayerDamage(1);
            }           
        }       
    }
}
