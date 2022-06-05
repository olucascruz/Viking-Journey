using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject hitBox;
    public float attackTime;
    public float distanceAttack;
    public bool isDead = false;
    public bool isAttacking = false;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player_Damage")
        {       
                isDead = true;
                Destroy(gameObject, 0.4f);
        }
    }
}
