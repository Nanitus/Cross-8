using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_SceneManager: MonoBehaviour {

    // Loads scene 1 depending on button pressed
    public void START() {
        SceneManager.LoadScene(1);
        GameManager.instance.Health = 3;
        GameManager.instance.Lives = 3;
    }

    // Loads scene 1 depending on button pressed
    // and gives player 3 health
    public void RETRY() {
        SceneManager.LoadScene(1);
        GameManager.instance.Health = 3;
    }

    // Loads scene 2 depending on button pressed
    public void CONTROLS() {
        SceneManager.LoadScene(2);
    }

    // Loads scene 0 depending on button pressed
    public void BACK() {
        SceneManager.LoadScene(0);
    }

    // Loads scene 3 depending on button pressed
    // and gives player 3 health
    // and gives player 3 lives
    public void RELOAD() {
        SceneManager.LoadScene(0);
    }

    // Exits game depending on button pressed
    public void EXIT() {
        Application.Quit();
    }
}