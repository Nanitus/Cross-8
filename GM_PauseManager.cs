using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_PauseManager : MonoBehaviour {

    CanvasGroup cg;                 // Canvas group

    public Button btnPause;         // Pause button

    public Text Livestext;          // Text for lives

    void Start() {
        // Pauses game
        cg = GetComponent<CanvasGroup>();

        if (!cg)
            cg = gameObject.AddComponent<CanvasGroup>();
        cg.alpha = 0.0f;

        if (btnPause)
            btnPause.onClick.AddListener(PauseGame);
    }

    void Update() {
        // Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        PauseGame();
    }

    public void PauseGame() {
        // Pause
        if (cg.alpha == 0.0f) {
            cg.alpha = 1.0f;
            Time.timeScale = 0.0f;
        }

        else {
            cg.alpha = 0.0f;
            Time.timeScale = 1.0f;
        }

        // Track of lives
        if (Livestext)
            Livestext.text = "Lives: " + GameManager.instance.Lives;
    }
}