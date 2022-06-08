using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject areaAtack;
    public float speed;
    private Transform positionPlayer;
    public float distanceAttack;
    private Animator anim;
    bool isAttack = false;
    public float delayAtk;
    public int life;
    public AudioSource TakeDamageSound;
    public AudioSource AttackSound;
    public Transform ColUp;
    public Transform ColDown;
    public bool colliding;
    public LayerMask layer;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        positionPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        DefaultMove();

    }

    // Update is called once per frame
    void Update()
    {   
        colliding = Physics2D.Linecast(ColDown.position, ColUp.position, layer);
        if(colliding)
        {
            DefaultMove(); 
        }
        

        if(positionPlayer)
        {
            if(positionPlayer.position.y > transform.position.y)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 4, ForceMode2D.Impulse);
            }
            
            if(Vector2.Distance(transform.position, positionPlayer.position) < distanceAttack && !isAttack)
            {   
                anim.SetBool("stunned", true);
                Invoke("Attack", delayAtk);
            }else{
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                anim.SetBool("stunned", false);
            }

        }
        
    }
        
    void Attack()
    {   
        if(!isAttack)
        {
            areaAtack.SetActive(true);
            anim.SetTrigger("attack");
            AttackSound.Play();
            isAttack = true;
            Invoke("deleyAttack", delayAtk);
            Invoke("ReverseMove", delayAtk);
        }

    }

    void DefaultMove(){
        
        if(positionPlayer){
            if(positionPlayer.position.x > transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            else
                {   
                    transform.eulerAngles = new Vector3(0, 180, 0);

                }
        }
    }

    void ReverseMove(){
        
        if(positionPlayer){
            if(positionPlayer.position.x < transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            else
                {   
                    transform.eulerAngles = new Vector3(0, 180, 0);

                }
            Invoke("DefaultMove", 2f);
        }
    }

    void deleyAttack()
    {
        areaAtack.SetActive(false);
        isAttack = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player_Damage")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 4, ForceMode2D.Impulse);
            anim.SetTrigger("hit");
            TakeDamageSound.Play();
            speed += 0.1f;
            life -= 1;
            
            
            if(life <= 0)
            {
                anim.SetTrigger("death");
                speed = 0;
                Destroy(gameObject, 0.6f);
            } 
        }
    }
}
