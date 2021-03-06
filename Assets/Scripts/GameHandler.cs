using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject scoreText;
    private int playerScore = 0;

    void Start()
    {
        UpdateScore();
    }

    public void AddScore(int points) {
        playerScore += points;
        UpdateScore();
    }

    // Update is called once per frame
    void UpdateScore()
    {
        Text scoreTextB = scoreText.GetComponent<Text>();
        scoreTextB.text = "" + playerScore;
    }
}
