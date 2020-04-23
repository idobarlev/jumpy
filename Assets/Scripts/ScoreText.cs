using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    #region DM
    public Text scoreText;          // score text in UI.
    public Text highScoreText;      // high score text in UI.

    public float pointsPerSec = 4f;
    public static bool isIncreasing = false;
    public static bool isHighScore;
    private static float _score = 0;
    private static float _highScore = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isHighScore = false;
        scoreText.text = "" + Score + "";   // update coins text.
    }

    // Update is called once per frame
    void Update()
    {
        if (isIncreasing)
        {
            Score += pointsPerSec * Time.deltaTime;
        }

        if (Score > HighScore)
        {
            HighScore = Score;
            isHighScore = true;
        }

        scoreText.text = "" + Mathf.Round(Score) + "";   // update score text.
        highScoreText.text = "" + Mathf.Round(HighScore) + "";   // update high score text.
    }

    #region Get & Set
    public static float Score { get => _score; set => _score = value; }
    public static float HighScore { get => _highScore; set => _highScore = value; }
    #endregion
}
