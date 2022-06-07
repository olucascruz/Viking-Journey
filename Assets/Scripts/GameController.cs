using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    public Text coinText;
    public Text lifeText;
    public int coins = 10;
    public int lives = 1;
    public static GameController gc;
    public GameObject GameOverScreen;
    public GameObject pauseMenu;
    bool isGameOver = false;


    // Start is called before the first frame update
    void Awake()
    {   
        if(gc == null)
        {
            gc = this;
        }
        else if(gc != this)
        {
            Destroy(gameObject);
        }
        if(coinText && lifeText)
        {
            RefreshScreen();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 0){
            isGameOver = true;
            Invoke("GameOver", 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.P) && !isGameOver)
        {
            Pause();
        }
    }

    public void SetLives(int life)
    {
        lives += life;
        if(lives < 0)
        {
            lives = 0;
        }
        if(lives > 5)
        {
            lives = 5;
        }
        RefreshScreen();
    }
    
    public void SetCoins(int coin)
    {
        coins += coin;
        if(coins < 0)
        {
            coins = 0;
        }
        RefreshScreen();
    }

    public void RefreshScreen()
    {
        lifeText.text = lives.ToString();
        coinText.text = coins.ToString();
    }
    
    void Pause()
    {
        if(pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    
    void GameOver()
    {
        GameOverScreen.SetActive(true);
    }
    public void Reset(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
