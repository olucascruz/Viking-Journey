using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckBoss : MonoBehaviour
{   
    private Transform Boss;
    private Transform Player;


    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss").transform;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Boss && Player){
            SceneManager.LoadScene("historyFinal");
        }
    }
}
