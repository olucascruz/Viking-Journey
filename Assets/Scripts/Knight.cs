using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Enemy
{   
    private Animator anim;
    private Rigidbody2D rig;
    public Transform ColUp;
    public Transform ColDown;
    public bool colliding;
    
    public float distance;

    bool isRight = true;

    public Transform groundCheck;

    public LayerMask layer;

    private Transform positionPlayer;
    private AudioSource sound;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        positionPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(positionPlayer)
        {
            Move();
            if(Vector2.Distance(transform.position, positionPlayer.position) < distanceAttack && !isAttacking){
                Invoke("Attack", attackTime);
            }
        }
        if(isDead){
            anim.SetTrigger("death");  
        }
    }

    void Move(){
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        colliding = Physics2D.Linecast(ColDown.position, ColUp.position, layer);
        
        if(ground.collider == false || colliding)
        {
            if(isRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = true;
            }
        }

        if(Vector2.Distance(transform.position, positionPlayer.position) < distanceAttack*5){
            if(positionPlayer.position.x >= transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = true;
            }
        }
        
    }

    void Attack(){
        sound.Play();
        anim.SetTrigger("attack");
        hitBox.SetActive(true);
        isAttacking = true;
        Invoke("DelayAttack", attackTime);
    }

    void DelayAttack(){
        hitBox.SetActive(false);
        isAttacking = false;
    }
}
