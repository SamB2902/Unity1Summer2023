using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeStart;
    public int minutes;
    public int seconds;
    public TMP_Text timerText;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        timeStart = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            TimerUpdate();
        }
    }

    void TimerUpdate()
    {
        //count up the timer
        timeStart += Time.deltaTime;
        minutes = Mathf.FloorToInt(timeStart / 60);
        seconds = Mathf.FloorToInt(timeStart % 60);
        if(seconds > 9)
        {
            timerText.text = $"{minutes}:{seconds}";
        }
        else
        {
            timerText.text = $"{minutes}:0{seconds}";
        }
    }
}
