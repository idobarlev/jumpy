using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreText : MonoBehaviour
{
    #region DM
    public Text scoreText;
    #endregion

    // Start is called before the first frame update
    void Start() {
        scoreText.text = "your score: " + 00 + "";
    }

    // Update is called once per frame
    void Update() {

        if(ScoreText.isHighScore) {
            scoreText.text = "new highscore: " + Mathf.Round(ScoreText.Score) + "";
        }
        else {
            scoreText.text = "your score: " + Mathf.Round(ScoreText.Score) + "";
        }
    }
}
