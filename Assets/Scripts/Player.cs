using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    private Animator anim;
    public bool doubleJump;

    public bool isJumping;

    public GameObject hitBox;
    public float attackTime;
    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Attack();
        
    }

    void Move(){
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if(movement > 0f){
        anim.SetBool("run", true);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if(movement < 0f){
        anim.SetBool("run", true);
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if(movement == 0f){
        anim.SetBool("run", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
        {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);

        }else{
            if(doubleJump)
            {
                rig.AddForce(new Vector2(0f, JumpForce*1.2f), ForceMode2D.Impulse);
                doubleJump = false;
            }
        }

        }

    }

    void Attack(){
         if(!isAttacking){
            if (Input.GetKeyDown(KeyCode.J))
            {
                anim.SetTrigger("attack");
                hitBox.SetActive(true);
                isAttacking = true;
                Invoke("DelayAttack", attackTime);
            }
         }
    }

    void DelayAttack(){
        hitBox.SetActive(false);
        isAttacking = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);

        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
