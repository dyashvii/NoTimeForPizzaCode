using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    //public Serve serveScript;
    //public Trash trashScript;

    //int score1 = 5;
    //int score2 = 2;
    //int score3 = 1;

    void UpdateScoreText()
    {
        int correctPizza = Serve.CorrectPizza;
        int wrongPizza = Serve.WrongPizza;
        int trashUsed = Trash.trashUsed;

        int totalScore = (correctPizza * 100) - (wrongPizza * 120) - (trashUsed * 3);

        scoreText.text = $"{correctPizza}\n\n\n\n{wrongPizza}\n\n\n\n{trashUsed}\n\n\n\n\n{totalScore}";

        //int totalScore = (score1 * 100) - (score2 * 120) - (score3 * 3);
        //scoreText.text = $"{score1}\n\n\n\n{score2}\n\n\n\n{score3}\n\n\n\n\n{totalScore}";
    }

    void Update()
    {
        UpdateScoreText();
    }
}
