using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Vector3 targetPosition;

    public Transform power;
    public float powerTime;

    void Start()
    {
        targetPosition = A.position;
    }

    void Update()
    {
        powerTime += Time.deltaTime;
        if (powerTime > 6f)
        {
            powerTime = 0;

            power.gameObject.SetActive(false);
            power.position = transform.position;
            power.gameObject.SetActive(true);
        }

        if (transform.position == A.position)
        {
            targetPosition = B.position;
        }
        if (transform.position == B.position)
        {
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 7 * Time.deltaTime);
    }
}
