using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {
        // scoreText = GetComponent<TextMeshProGUI
    }

    // Update is called once per frame
    public void IncreaseScore(int amount)
    {
        score += amount; //Add amount to score
        UpdateScoreText();
    }

    public void DecreaseScore(int amount)
    {
        score -= amount; //subtract from score
        UpdateScoreText(); //update UI
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
