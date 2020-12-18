using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    int currentScore;
    Text scoreText;

    void Start() {

        scoreText = GetComponent<Text>();
        scoreText.text = currentScore.ToString();
    }

    public void CalculateScore(int scorePerHit) {

        currentScore = currentScore + scorePerHit;
        scoreText.text = currentScore.ToString();
    }
}
