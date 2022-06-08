using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckBoss : MonoBehaviour
{   
    private Transform Boss;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Boss){
            SceneManager.LoadScene("historyFinal");
        }
    }
}
