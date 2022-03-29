
// Esse script foi feito baseado neste tutorial https://www.youtube.com/watch?v=JivuXdrIHK0

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    GameManager gm;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Start() {
        gm = GameManager.GetInstance();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu () {
        GameIsPaused = false;
        gm.LoadMenu();
    }

    public void QuitGame () {
        gm.QuitGame();
    }
}
