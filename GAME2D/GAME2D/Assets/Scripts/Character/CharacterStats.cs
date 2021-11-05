using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int life;

    public Transform skin;
    public Transform cam;
    public Transform hud;

    public Text lifeText;

    

    void Start()
    {
        
    }

    void Update()
    {
        if(transform.CompareTag("Player"))
        {
            lifeText.text = "X" + life.ToString();

            if (life == 1)
            {
                hud.GetComponent<Animator>().Play("HudDie", -1);
            }
        }
        

        if (life <= 0)
        {           
            skin.GetComponent<Animator>().Play("Die", -1);
        }   
        
       
    }

    public void PlayerDamage(int value )
    {
        life = life - value;       
        skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        cam.GetComponent<Animator>().Play("ShakyCam", -1);
        GetComponent<PlayerController>().audioSource.PlayOneShot(GetComponent<PlayerController>().damageSound);
    }
}
