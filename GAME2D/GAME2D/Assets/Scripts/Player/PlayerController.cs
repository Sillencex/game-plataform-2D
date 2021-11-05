using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;
    public AudioSource audioSource;
    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    public AudioClip damageSound;
    public AudioClip dashSound;

    public Transform groundCollider;
    public Transform skin;

    public Transform gameOverScreen;
    public Transform pauseScreen;

    public int comboNum;
    public float comboTime;
    public float dashTime;

    public string currentLevel;

    public LayerMask groundLayer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        currentLevel = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if(!currentLevel.Equals(SceneManager.GetActiveScene().name))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.Find("Spawn").transform.position;
        }

        if (GetComponent<CharacterStats>().life <= 0)
        {
            gameOverScreen.GetComponent<GameOver>().enabled = true;
            rb.simulated = false;
            this.enabled = false;
        }

        if (Input.GetButtonDown ("Cancel"))
        {
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
        }

        dashTime = dashTime + Time.deltaTime;
        //Dash
        if (Input.GetButtonDown("Fire3") && dashTime > 1)
        {
            audioSource.PlayOneShot(dashSound, 0.5f);

            dashTime = 0;
            skin.GetComponent<Animator>().Play("Dash", -1);
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            rb.AddForce(new Vector2(skin.localScale.x  * 600, 0));
            Invoke("RestoreGravityScale", 0.2f);
        }

        comboTime = comboTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && comboTime > 0.5F)
        {
            comboNum++;
            if(comboNum> 2)
            {
                comboNum = 1;
            }

            comboTime = 0;
            skin.GetComponent<Animator>().Play("PlayerAttack1" + comboNum,-1);

            if(comboNum == 1)
            {
                audioSource.PlayOneShot(attack1Sound);
            }
            if (comboNum == 2)
            {
                audioSource.PlayOneShot(attack2Sound);
            }
        }

        if (comboTime >= 1)
        {
            comboNum = 0;
        }

        bool cantJump = Physics2D.OverlapCircle(groundCollider.position, 1f, groundLayer);

        if (cantJump && Input.GetButtonDown("Jump") && comboTime > 0.5f)
        {
            skin.GetComponent<Animator>().Play("Jump", -1);
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, 900));
        }
        vel = new Vector2(Input.GetAxisRaw("Horizontal") * 5, rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal")!= 0)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1); 
            skin.GetComponent<Animator>().SetBool("PlayerRun", true);
        }
        else
        {
            skin.GetComponent<Animator>().SetBool("PlayerRun", false);
        }
    }

    private void FixedUpdate()
    {
        if(dashTime > 0.3)
        {
            rb.velocity = vel;       
        }        
    }

    public void DestroyPlayer()
    {
        Destroy(transform.gameObject);
    }

    void RestoreGravityScale()
    {
        rb.gravityScale = 6;
    }
}
