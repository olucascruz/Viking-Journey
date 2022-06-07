using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public string NameCurrentScene;
    // Start is called before the first frame update
    void Start()
    {   
        NameCurrentScene = SceneManager.GetActiveScene().name;
    }
    // Update is called once per frame
    void Update()
    { 
    }

    public void NextScene()
    {
        SceneManager.LoadScene(NameCurrentScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
