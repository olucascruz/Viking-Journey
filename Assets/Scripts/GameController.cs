using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    public Text coinText;
    public int coins = 10;
    public Text lifeText;
    public int lives = 1;
    public static GameController gc;
    public GameObject GameOverScreen;

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
        RefreshScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 0){
            Invoke("GameOver", 0.5f);
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
