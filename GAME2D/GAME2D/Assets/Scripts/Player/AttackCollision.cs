using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    public Transform Player;
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
            if (Player.GetComponent<PlayerController>().comboNum == 1)
            {
                collision.GetComponent<CharacterStats>().life--;
            }
        }
        if (collision.CompareTag("Enemy"))
        {
            if (Player.GetComponent<PlayerController>().comboNum == 2)
            {
                collision.GetComponent<CharacterStats>().life -= 2;
            }

        }
    }
}
