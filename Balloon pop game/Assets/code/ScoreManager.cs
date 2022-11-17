using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;
    public int scoreToGive = 10;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        // Reference score manager component
        scoreManager = GameObject.Find("ScoreMananger").GetComponent<ScoreManager>();
    }

    public void IncreaseScoreText(int amount)
    {
        score += amount;

        UpdateScoreText();
    }

    public void DecreaseScoreText(int amount)
    {
        score -= amount;

        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
