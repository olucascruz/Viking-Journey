using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScriptFinalText : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    void Start()
    {
        Destroy(GameObject.Find("HudCanvas"));
        Invoke("ShowText1", 0.5f);        
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
        Invoke("GoInitialMenu", 3.5f);
    }

    void GoInitialMenu()
    {
        SceneManager.LoadScene("HomeMenu");
    }
}
