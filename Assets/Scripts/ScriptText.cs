using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScriptText : MonoBehaviour
{   
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowText1", 0.5f);
              
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            GoGame();
        }  
    }

    void ShowText1()
    {
        Text1.SetActive(true);
        Invoke("ShowText2", 3.5f);        

    }
    void ShowText2()
    {
        Text1.SetActive(false);
        Text2.SetActive(true);
        Invoke("ShowText3", 3.5f);
    }
    void ShowText3()
    {
        Text2.SetActive(false);
        Text3.SetActive(true);
        Invoke("ShowText4", 3.5f);
    }
    void ShowText4()
    {
        Text3.SetActive(false);
        Text4.SetActive(true);
        Invoke("ShowText5", 3.5f);  
    }
    void ShowText5()
    {
        Text4.SetActive(false);
        Text5.SetActive(true);
        Invoke("ShowText6", 3.5f);
    }
    void ShowText6()
    {
        Text5.SetActive(false);
        Text6.SetActive(true);
        Invoke("GoGame", 2f);
    }
    
    void GoGame()
    {
        SceneManager.LoadScene("lvl1");
    }
    
}
