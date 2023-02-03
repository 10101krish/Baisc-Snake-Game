using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text multiplyerText;
    public Text highScoreText;
    public Text highScoreTag;

    private int highScore = 0;
    private int score;
    private int multiplyer;

    void Start()
    {
        score = 0;
        multiplyer = 1;

        highScoreTag.gameObject.SetActive(false);
        DisplayScore();
        DisplayMultiplyer();
        DisplayHighScore();
    }

    public void AddScore(int points)
    {
        score += multiplyer * points;
        if (highScore < score)
        {
            highScoreTag.gameObject.SetActive(true);
            highScoreTag.color = Color.yellow;
        }
        DisplayScore();
    }

    public void ResetScore()
    {
        UpdateHighScore();
        highScoreTag.gameObject.SetActive(false);
        score = 0;
        DisplayScore();
    }

    public void IncrementMultiplyer()
    {
        multiplyer = Mathf.Clamp(multiplyer + 1, 1, 20);
        DisplayMultiplyer();
    }

    public void ResetMultiplyer()
    {
        multiplyer = 1;
        DisplayMultiplyer();
    }

    private void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    private void DisplayMultiplyer()
    {
        multiplyerText.text = multiplyer.ToString() + "X";
        if (multiplyer < 5)
        {
            multiplyerText.color = Color.white;
            multiplyerText.fontSize = 30;
        }
        else if (multiplyer >= 5 && multiplyer < 10)
        {
            multiplyerText.color = Color.cyan;
            multiplyerText.fontSize = 33;
        }
        else if (multiplyer >= 10 && multiplyer < 15)
        {
            multiplyerText.color = Color.green;
            multiplyerText.fontSize = 36;
        }
        else
        {
            multiplyerText.color = Color.yellow;
            multiplyerText.fontSize = 39;
        }
    }

    private void DisplayHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
        highScoreText.color = Color.yellow;
    }

    private void UpdateHighScore()
    {
        if (highScore < score)
            PlayerPrefs.SetInt("HighScore", score);
        DisplayHighScore();
    }
}
