using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaController : MonoBehaviour
{
    int tradeLife;

    public Transform lifeBar;

    void Start()
    {
        tradeLife = GetComponent<CharacterStats>().life;
    }

    void Update()
    {
        if (tradeLife != GetComponent<CharacterStats>().life)
        {
            tradeLife = GetComponent<CharacterStats>().life;
            GetComponent<CharacterStats>().skin.GetComponent<Animator>().Play("BreakingDoor", -1);
        }

        if (GetComponent<CharacterStats>().life <= 0)
        {
            Destroy(transform.gameObject);
        }

        lifeBar.localScale = new Vector3((1 * GetComponent<CharacterStats>().life) / 10f, 1, 1); ;
    }
}
