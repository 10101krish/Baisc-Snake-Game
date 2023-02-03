using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Score score;
    private Lives lives;
    private Food food;
    private PowerUp powerUp;

    private bool gameRunning;

    void Start()
    {
        gameRunning = true;
        score = FindObjectOfType<Score>();
        lives = FindObjectOfType<Lives>();
        food = FindObjectOfType<Food>();
        powerUp = FindObjectOfType<PowerUp>();
    }

    public void FoodConsumed()
    {
        score.IncrementMultiplyer();
        if (powerUp.DoubleModeEnabled())
            score.AddScore(2);
        else
            score.AddScore(1);
    }

    public void GoldenConsumed()
    {
        if (powerUp.DoubleModeEnabled())
            score.AddScore(10);
        else
            score.AddScore(5);
        food.GoldenDestroyed();
    }

    public void ObstacleHit()
    {
        if (!powerUp.GodModeEnabled())
        {
            score.ResetMultiplyer();
            lives.DecreaseCurrentLives();
            if (lives.getCurrentLives() == 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        // gameRunning = false;
        // score.ResetScore();
        // lives.ResetLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool GetGameStatus()
    {
        return gameRunning;
    }

    public void PowerUpHit()
    {
        powerUp.PowerUpDestroyed();
    }
}
