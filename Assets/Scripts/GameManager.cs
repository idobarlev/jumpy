using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameManager : MonoSingleton<GameManager> {
    #region DM

    // -- Events --
    public delegate void GameDelegate();
    // -------------

    // -- Canvas Layouts --
    public GameObject countDownPage;
    public GameObject gameOverPage;
    enum PageState {
        None,
        Start,
        GameOver,
        CountDown
    }
    #endregion

    void Start() {
        StartGame();
    }

    // The function is initing new game, called at new game.
    public void StartGame() {

        // Init game.
        ScoreText.Score = 0;
        CoinsText.Coins = 0;
        ScoreText.isIncreasing = true;
        PlayerMovement.isEnableMove = true;

        // Set count down layout.
        SetPageState(PageState.CountDown);
    }

    // The function is handling game over.
    public void GameOver() {

        // Stop movement.
        PlayerMovement.isEnableMove = false;

        // Finish inc.
        ScoreText.isIncreasing = false;

        // Update highScore.
        int curHighScore = PlayerPrefs.GetInt("highScore");
        if ((int)(ScoreText.Score) > curHighScore) {
            PlayerPrefs.SetInt("highScore", (int)(ScoreText.Score));
        }

        // Update coins.
        PlayerPrefs.SetInt("coins", CoinsText.Coins + PlayerPrefs.GetInt("coins"));

        // Set game over layout.
        SetPageState(PageState.GameOver);
    }

    // Back to main menu secne.
    public void BackToMainMenu() {
        ScoreText.Score = 0;
        CoinsText.Coins = 0;
        SceneManager.LoadScene("MainMenu");
    }

    // Reset game secne.
    public void ResetGame() {
        SceneManager.LoadScene("Game");
    }

    // The function is enabling the page that we need to see at cur state.
    private void SetPageState(PageState state) {
        switch (state) {
            case PageState.None:
                countDownPage.SetActive(false);
                gameOverPage.SetActive(false);
                break;

            case PageState.GameOver:
                countDownPage.SetActive(false);
                gameOverPage.SetActive(true);
                break;

            case PageState.CountDown:
                countDownPage.SetActive(true);
                gameOverPage.SetActive(false);
                break;
        }
    }

    // -------------------------- AT EVENTS ---------------------------
    void OnEnable() {
        PageCountDown.OnCountDownFinished += OnCountDownFinished;
    }

    void OnDisable() {
        PageCountDown.OnCountDownFinished -= OnCountDownFinished;
    }
    // ----------------------------------------------------------------

    // Event called from PgaeCoungtDown. what action to do at CountDownFinished.
    void OnCountDownFinished() {
        SetPageState(PageState.None);
    }

    // ----------------------------------------------------------------
}
