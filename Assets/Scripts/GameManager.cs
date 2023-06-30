using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Drawing;

public class GameManager : Singleton<GameManager>
{

    public GameObject loseUI;
    public int points = 0;
    public TextMeshProUGUI scoreText;
    public int highscore;
    public TextMeshProUGUI highScoreText;


    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void ShowLoseUI()
    {
        loseUI.SetActive(true);
        highscore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = $"High Score: {highscore.ToString()}";
    }
    public void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void OnGameOver()
    {
        Time.timeScale = 0;
        UpdateHighscore();
        ShowLoseUI();
       
    }

    public void UpdateScore()
    {
        points++;
        scoreText.text = points.ToString();
        AudioManager.instance.Play("point");

    }

    public void IncreaseScore()
    {
        points++;
        scoreText.text = points.ToString();
    }

    public void UpdateHighscore()
    {
        if (points > PlayerPrefs.GetInt("Highscore"))
        {
            highscore = points;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }
    }

}