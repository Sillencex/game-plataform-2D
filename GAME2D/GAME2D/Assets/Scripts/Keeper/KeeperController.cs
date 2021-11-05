using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public AudioSource audioSource;
    public AudioClip dieSound;

    public Transform skin;
    public Transform drawDistance;

    public bool goRight;

    void Start()
    {

    }

    void Update()
    {
        if (GetComponent<CharacterStats>().life <= 0)
        {
            audioSource.PlayOneShot(dieSound);
            drawDistance.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
        }



        //Inimigo ataca enquanto estiver no colisor
        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack"))
        {
            return;
        }

        if (goRight == true)
        {
            skin.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
            {
                goRight = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, 1f * Time.deltaTime);
        }
        else
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
            {
                goRight = true;
            }
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, 1f * Time.deltaTime);
        }

    }
}
