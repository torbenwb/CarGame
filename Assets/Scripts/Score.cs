using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Int highScore;
    public float timer = 10f;
    public float minTimePerStar = 1.0f;
    public float maxTimePerStar = 2.0f;
    public float minTimeDegradation = 0.05f;
    public float maxTimeDegradation = 0.1f;
    float totalTime = 0.0f;

    public Text[] scoreDisplay;
    public Curve scaleCurve;
    public Text[] timerDisplay;
    public GameObject defaultTimer;
    public GameObject lateTimer;

    // AddScore increments the value of score by 1.
    public void AddScore()
    {
        if (timer > 0f)
        {
            
            
            score++;
            scaleCurve.PlayCurve();
            foreach(Text t in scoreDisplay){
                t.text = "Score: " + score;
            }
            

            // new 
            timer += Random.Range(minTimePerStar, maxTimePerStar);
            
            if (score > highScore.RuntimeValue)
            {
                highScore.RuntimeValue = score;
            }
        }
    }

    void Update()
    {
        totalTime += Time.deltaTime;
        minTimePerStar -= minTimeDegradation * Time.deltaTime;
        minTimePerStar = Mathf.Clamp(minTimePerStar, 0.5f, maxTimePerStar);
        maxTimePerStar -= maxTimeDegradation * Time.deltaTime;
        maxTimePerStar = Mathf.Clamp(maxTimePerStar, minTimePerStar, maxTimePerStar);

        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            foreach(Text t in timerDisplay){
                t.text = timer > 0.0f ? timer.ToString("0.0") : "Out of time!";
            }

            if (timer >= 4.0f && !defaultTimer.activeSelf){
                defaultTimer.SetActive(true);
                lateTimer.SetActive(false);
            } 
            if (timer < 4.0f && !lateTimer.activeSelf){
                defaultTimer.SetActive(false);
                lateTimer.SetActive(true);
            }
            

            if (timer < 0.0f){
                GameManager.instance.Invoke("LoadStart", 1.0f);
            }
        }
    }
}
