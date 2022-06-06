using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{   
    public GameObject HealingOffer;
    public GameObject NoCoins;
    private GameController gcPlayer;
    private Animator anim;
    private AudioSource sound;
    bool contact = false;



    // Start is called before the first frame update
    void Start()
    {
        gcPlayer = GameController.gc;
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !contact)
        {

            if(gcPlayer.coins < 5)
            {
                if(NoCoins)
                {
                    GameObject textNoCoins = Instantiate(NoCoins);
                    textNoCoins.transform.position = new Vector3(    
                    this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y+0.8f,
                    this.gameObject.transform.position.z);
                }    
                     
            }
            else
            {
                GameObject textHealingOffer = Instantiate(HealingOffer);
                    textHealingOffer.transform.position = new Vector3(    
                    this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y+0.8f,
                    this.gameObject.transform.position.z);
            }
            contact = true;
        }

        if(collision.gameObject.tag == "cure")
        {
            sound.Play();
            anim.SetTrigger("Cure");
            gcPlayer.SetLives(5);
            gcPlayer.SetCoins(-5);
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {   
            Destroy(GameObject.Find(HealingOffer.name + "(Clone)"));
            Destroy(GameObject.Find(NoCoins.name + "(Clone)"));
        }
        contact = false;
    }


    
}
