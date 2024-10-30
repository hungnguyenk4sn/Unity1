using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int Score;

    bool isEndgame;
    bool isStartFirstTime;

    public GameObject pnlEndGame;
    public TMP_Text ScoreEndGame;
    public Button Restart;

    public TMP_Text CurrentScore;
    public static GameManager instance { get; private set;}

    private void Awake()
    {
         instance=this;
    }
    private void Start()
    {
        Score = 0;
        Time.timeScale = 0;
        isEndgame = false;
        isStartFirstTime = true;
        pnlEndGame.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (isEndgame)
        {
            if (Input.GetMouseButtonDown(0)&& isStartFirstTime)
            {
                /*   Time.timeScale = 1;*/
                StarGame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
            }
        }
        
    }
      public void StarGame()
    {
        SceneManager.LoadScene(0);
    }

    public void CollectScore()
    {
        Score++;
        CurrentScore.text = "Score: " + Score;
        

    }
    public void EndGame()
    {
        isStartFirstTime = false;
        isEndgame = true;
        Time.timeScale = 0;
        pnlEndGame.gameObject.SetActive(true);
        ScoreEndGame.text = "Your Score: " + Score;
    }
}
