using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycheck : MonoBehaviour
{
    private bool isEnemy = false;
    private bool isEnemyEnter, isEnemyStay, isEnemyExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool IsEnemy()
    {
        if(isEnemyEnter || isEnemyStay)
        {
            isEnemy = true;

        }
        else if (isEnemyExit)
        {
            isEnemy = false;

        }
        isEnemyEnter = false;
        isEnemyStay = false;
        isEnemyExit = false;
        return isEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {

            isEnemyEnter = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            isEnemyStay = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            isEnemyExit = true;
        }
    }
}
