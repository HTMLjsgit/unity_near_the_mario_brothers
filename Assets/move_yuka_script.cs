using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_yuka_script : MonoBehaviour
{
    private bool tenkan_left = false;
    private bool tenkan_right = false;
    private float speed;
    public GameObject player;
    // Start is called before the first frame update
    Rigidbody2D rb;
    Rigidbody2D player_rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tenkan_left == false && tenkan_right == false)
        {
            speed = 3f;
        }

        if (tenkan_left && !tenkan_right)
        {
            speed = 3f;
        }

        if (tenkan_right && !tenkan_left)
        {
            speed = -3f;
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "tenkan_left")
        {
            tenkan_left = true;
            tenkan_right = false;

        }

        if (collision.gameObject.tag == "tenkan_right")
        {
            tenkan_right = true;
            tenkan_left = false;

        }


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tenkan_left")
        {
            tenkan_left = true;
            tenkan_right = false;
        }

        if (collision.gameObject.tag == "tenkan_right")
        {
            tenkan_right = true;
            tenkan_left = false;
        }
    }
}
