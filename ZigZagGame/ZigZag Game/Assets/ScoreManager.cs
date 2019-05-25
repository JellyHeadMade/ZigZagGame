using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int score;
    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementScore()
    {
        score += 1;
    }

    public void startScore()
    {
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }

    public void stopScore()
    {
        CancelInvoke("incrementScore");

        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highscore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
