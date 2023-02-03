using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Text livesText;
    public int startingLives = 3;
    private int currentLives;

    private void Start()
    {
        currentLives = startingLives;
        DisplayLives();
    }

    public int getCurrentLives()
    {
        return currentLives;
    }

    public void DecreaseCurrentLives()
    {
        currentLives--;
        DisplayLives();
    }

    private void DisplayLives()
    {
        livesText.text = currentLives.ToString();
        livesText.color = Color.red;
    }

    public void ResetLives()
    {
        currentLives = startingLives;
        DisplayLives();
    }

}
