using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 5;
    public float timer = 10f;
    public float timePerStar = 2.0f;

    public Text scoreDisplay;
    public Curve scaleCurve;
    public Text timerDisplay;


    // AddScore increments the value of score by 1.
    public void AddScore()
    {
        if (timer > 0f)
        {
            
            score++;
            scaleCurve.PlayCurve();
            scoreDisplay.text = "Score: " + score;

            // new 
            timer += timePerStar;
            
            if (score > highScore)
            {
                highScore = score;
                
            }
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerDisplay.text = timer > 0.0f ? timer.ToString("0.0") : "Out of time!";

        
    }
}
