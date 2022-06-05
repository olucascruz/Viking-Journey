using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   
    public Text lifeText;
    public int lives = 5;
    public static GameController gc;

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
        
    }

    public void SetLives(int life)
    {
        lives += life;
        RefreshScreen();
    }
    public void RefreshScreen()
    {
        lifeText.text = lives.ToString();
    }
}
