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
    bool stunned = false;
    public float delayAtk;
    public float timeStun;
    public int life;
    public AudioSource TakeDamageSound;
    public AudioSource AttackSound;
    private int hits = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        positionPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {   
        if(!stunned){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetBool("stunned", false);
        }
        else
        {
            anim.SetBool("stunned", true);
        }
        if(positionPlayer)
        {
        if(positionPlayer.position.y < transform.position.y)
        {
            DefaultMove();
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
        }
        

        if(Vector2.Distance(transform.position, positionPlayer.position) < distanceAttack && !isAttack)
            {   
                Invoke("Attack", 1.5f);
            }
        }
        

    void Attack()
    {
        areaAtack.SetActive(true);
        anim.SetTrigger("attack");
        isAttack = true;
        AttackSound.Play();
        Invoke("deleyAttack", delayAtk);
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

    void deleyAttack()
    {
        areaAtack.SetActive(false);
        isAttack = false;
    }
    void stun()
    {
        stunned = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player_Damage")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 4, ForceMode2D.Impulse);
            anim.SetTrigger("hit");
            TakeDamageSound.Play();
            speed += 0.1f;
            hits += 1;
            life -= 1;
            
            if(hits == 2){
                stunned = true;
                Invoke("stun", timeStun);
                hits = 0;
             }
            
            if(life <= 0)
            {
                anim.SetTrigger("death");
                speed = 0;
                Destroy(gameObject, 0.5f);
            } 
        }
    }
}
