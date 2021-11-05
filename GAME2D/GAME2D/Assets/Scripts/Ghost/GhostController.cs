using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public Transform skin;

    public bool goRight;

    void Start()
    {
        
    }

    void Update()
    {
        if (goRight == true)
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
            {
                transform.position = pointA.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, 5f * Time.deltaTime);
        }
        else
        {
            skin.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
            {
                transform.position = pointB.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, 5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CharacterStats>().PlayerDamage(5);
        }
    }
}
