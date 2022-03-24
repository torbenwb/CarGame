using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 5;
    public float timer = 10f;

    public Text scoreDisplay;
    public Text timerDisplay;

    // AddScore increments the value of score by 1.
    public void AddScore()
    {
        if (timer > 0f)
        {
            
            score++;
            print("Score: " + score);
            scoreDisplay.text = "Score: " + score;
            
            if (score > highScore)
            {
                highScore = score;
                print("Way to go! You got a new high score.");
            }
        }
        else
        {
            print("Out of time!");
            
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerDisplay.text = timer > 0.0f ? timer.ToString("0.0") : "Out of time!";
    }
}
