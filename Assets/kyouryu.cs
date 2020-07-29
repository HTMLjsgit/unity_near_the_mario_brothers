using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyouryu : MonoBehaviour
{
    float direction;
    public GameObject player;
    private float enemy_move_speed = 15f;
    private bool Rendered = true;
      Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Animator anim = GetComponent<Animator>();

        SpriteRenderer player_sprite = player.GetComponent<SpriteRenderer>();
        SpriteRenderer my_sprite = GetComponent<SpriteRenderer>();
        Vector3 playerPos = this.player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, enemy_move_speed * Time.deltaTime);
        float player_position_han = transform.position.x - player.transform.position.x;
        if (player_position_han < 0)
        {
            my_sprite.flipX = true;
        }
        else
        {
            my_sprite.flipX = false;
        }
        anim.SetBool("run", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Animator anim = GetComponent<Animator>();
        Vector3 playerPos = this.player.transform.position;
        if (collision.gameObject.tag == "player")
        {

            anim.SetBool("kami", true);
            enemy_move_speed = 0f;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if(collision.gameObject.tag == "player")
        {
           audio.Play();
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Animator anim = GetComponent<Animator>();

        if (collision.gameObject.tag == "player")
        {
            anim.SetBool("kami", false);
            anim.SetBool("run", false);
            enemy_move_speed = 15f;
        }
    }


}
