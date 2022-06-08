using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneMenu : MonoBehaviour
{
    
    public void EnterGame()
    {
        SceneManager.LoadScene("history");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
