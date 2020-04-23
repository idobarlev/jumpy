using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Handle Main Menu buttons actions.
    public void Game() {
        SceneManager.LoadScene("Game");
    }

    public void Store() {
        Debug.Log("I am store button :-)");
        //SceneManager.LoadScene("Store");
    }
}
