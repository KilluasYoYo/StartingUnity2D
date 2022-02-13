using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public float fillFraction;
    public bool isAnsweringQuestion;
    float timervalue;
    void Update()
    {
        updateTimer();
    }

    public void CanselTimer()
    {
        timervalue = 0;
    }

    void updateTimer()
    {
        timervalue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timervalue > 0)
            {
                fillFraction = timervalue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timervalue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timervalue > 0)
            {
                fillFraction = timervalue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timervalue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
