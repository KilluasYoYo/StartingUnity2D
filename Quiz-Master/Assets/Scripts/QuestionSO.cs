using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "QuizQuestion")]

public class QuestionSO : ScriptableObject 
{
    [TextArea(2,6)]
    [SerializeField] string question = "Type your new question text here";
    [SerializeField] string[] Answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    public string Getquestion()
    {
        return question;
    }

    public int GetCorrectAnswer()
    {
        return correctAnswerIndex;
    }

    public string getAnswer(int index)
    {
        return Answers[index];
    }
}