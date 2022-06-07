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
    bool footGround = false;

    public GameObject hitBox;
    public GameObject blood;
    public GameObject cure;
    public float attackTime;
    public float takeDamageTime;
    bool isAttacking = false;
    bool isIntangible = false;

    private GameController gcPlayer;

    public AudioSource JumpSound;
    public AudioSource AttackSound;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gcPlayer = GameController.gc;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Attack();
        if (Input.GetKeyDown(KeyCode.K) && gcPlayer.coins >= 5)
            {   
                cure.SetActive(true);
                Invoke("NoCure", 0.1f);
            }
        if(gcPlayer.lives == 0)
        {
            Invoke("Death", 0.2f);
        }
    }

    void Move(){
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if(movement > 0f){
            if(!isJumping)
            {
                anim.SetBool("run", true);
            }
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if(movement < 0f){
            if(!isJumping)
            {
                anim.SetBool("run", true);
            }
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
            if(!isJumping && footGround)
        {
                JumpSound.Play();
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);

        }else{
            if(doubleJump)
            {
                JumpSound.Play();
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
                AttackSound.Play();
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

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            footGround = true;
        }
        if(collision.gameObject.tag == "Damage" && !isIntangible)
        {       
                blood.SetActive(true);
                gcPlayer.SetLives(-1);
                isIntangible = true;
                Invoke("DelayTakeDamage", takeDamageTime);
        }

        if(collision.gameObject.tag == "Coin")
        {
            gcPlayer.SetCoins(1);
            Destroy(collision.gameObject, 0.10f);
        }
    
    }
    
     void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            footGround = false;
        }
    }

    void NoCure(){
        cure.SetActive(false);
    }

    void DelayTakeDamage()
    {
        blood.SetActive(false);
        isIntangible = false;
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
