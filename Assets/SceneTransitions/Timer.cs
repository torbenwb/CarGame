using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time = 0.0f;
    private bool timerActive = false;

    public delegate void HandleTimer();
    public event HandleTimer OnTimerEnd;

    public void StartTimer(float time)
    {
        this.time = time;
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            time -= Time.deltaTime;
            if (time <= 0.0f)
            {
                time = 0.0f;
                timerActive = false;
                OnTimerEnd?.Invoke();
            }
        }
        
    }
}
