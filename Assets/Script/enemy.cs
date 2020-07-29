using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject enemycheck;
    public GameObject enemycheck2;
    private bool isEnemy = false;
    private bool isEnemy2 = false;
    public GameObject exsplosionPrehab;
    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        enemycheck enemyscript = enemycheck.GetComponent<enemycheck>();
        enemycheck enemyscript2 = enemycheck2.GetComponent<enemycheck>();
        isEnemy = enemyscript.IsEnemy();
        isEnemy2 = enemyscript2.IsEnemy();
        if(isEnemy || isEnemy2)
        {
            Instantiate(exsplosionPrehab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject,1f);
        }
    }
}
