using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public string NameCurrentScene;
    private GameController gcPlayer;

    // Start is called before the first frame update
    void Start()
    {   
        gcPlayer = GameController.gc;
    }
    // Update is called once per frame
    void Update()
    { 
        NameCurrentScene = SceneManager.GetActiveScene().name;
    }

   


    public void NextScene()
    {
        gcPlayer.SetLives(5);
        SceneManager.LoadScene(NameCurrentScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
