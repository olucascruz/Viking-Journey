using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{   
    public string Scene;
    public GameObject UiObject;
    public GameObject EventsObject;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {   
            DontDestroyOnLoad(EventsObject);
            DontDestroyOnLoad(UiObject);
            SceneManager.LoadScene(Scene);
        }
    }
}
