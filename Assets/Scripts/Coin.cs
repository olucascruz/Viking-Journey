using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CircleCollider2D col;
    private AudioSource sound;
   
    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        sound = GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            sound.Play();
            col.enabled = false;
        }
    }
}
