using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    float currentTime;
    public Text currentTimeText;

    //Score variables
    public int timescore;
    public float multiplier = 5;
    void Start()
    {
        //Acivate timer on level start
        timerActive = true;
        currentTime = 0;
    }

    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        // Timer score calculation
        timescore = Mathf.RoundToInt(currentTime * multiplier);
        PlayerPrefs.SetInt("timescore", timescore);        

        // Timer HUD calculation and display string
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
