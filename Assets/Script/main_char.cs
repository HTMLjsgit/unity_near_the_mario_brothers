using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_char : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite;
    float direction = 0f;
    public float scroll = 30f;
    public float flap = 0.2f;
    public GameObject ground;
    private bool isGround = false;
    public float jumpHeight;
    private bool isJump = false;
    float seconds;
    private bool isEnemy = false;
    private bool isEnemy2 = false;
    private AudioSource[] audioSources;
    public GameObject enemycheck;
    public GameObject enemycheck2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audioSources = GetComponents<AudioSource>();

        enemycheck.SetActive(false);
        enemycheck2.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        seconds += Time.deltaTime;
        groundcheck groundscript = ground.GetComponent<groundcheck>();
        enemycheck enemyscript = enemycheck.GetComponent<enemycheck>();
        enemycheck enemyscript2 = enemycheck2.GetComponent<enemycheck>();
        isGround = groundscript.IsGround();
        isEnemy = enemyscript.IsEnemy();
        isEnemy2 = enemyscript2.IsEnemy();
       
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //Rigidbody2D rb_enemy = 
        if (isGround){
           if (vertical > 0 && !isJump)
              {
                rb.velocity = new Vector2(0, 15f); //ここでジャンプ調整
                animator_setting("jump", true);
                animator_setting("run", false);
                Debug.Log("ジャンプしたぞ！");
                //animator_setting("run", false);
                audioSources[0].Play();

                isJump = true;
              }
          else
              {
                animator_setting("jump", false);
                isJump = false;
              }
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {

            enemycheck.SetActive(true);
            enemycheck2.SetActive(true);
            audioSources[1].Play();
            animator_setting("naguri", true);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            animator_setting("naguri", false);
            enemycheck.SetActive(false);
            enemycheck2.SetActive(false);
        }
        if (horizon > 0)
        {
            direction = 1.5f;
            animator_setting("run", true);
            sprite.flipX = false;
        }
        else if (horizon < 0)
        {
            direction = -1.5f;
            animator_setting("run", true);


            sprite.flipX = true;


        }
        else
        {

            direction = 0f;
            animator_setting("run", false);

            // animator_setting("jump", false);
        }
        rb.velocity = new Vector2(scroll * direction, rb.velocity.y);

    }





    private IEnumerator DelayMethod(float waitTime, Action action)
    {
       yield return new WaitForSeconds(waitTime);
       action();
    }
    public void animator_setting(string name, bool config)
    {
        animator.SetBool(name, config);
    }

}
