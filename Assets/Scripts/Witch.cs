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
        if(collision.gameObject.tag == "Player")
        {

            if(gcPlayer.coins < 5)
            {
                NoCoins.SetActive(true);
            }
            else
            {
                HealingOffer.SetActive(true);
            }
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
            HealingOffer.SetActive(false);
            NoCoins.SetActive(false);
        }
    }


    
}
