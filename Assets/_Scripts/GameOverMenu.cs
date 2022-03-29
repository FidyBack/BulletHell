using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {
    GameManager gm;

    public GameObject GameOverMenuUI;

    private void Start() {
        gm = GameManager.GetInstance();
    }

    private void Update() {
        if (gm.lifes <= 0) {
            GameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Restart() {
        GameOverMenuUI.SetActive(false);
        gm.Restart();
    }

    public void LoadMenu () {
        GameOverMenuUI.SetActive(false);
        gm.LoadMenu();
    }

    public void QuitGame () {
        gm.QuitGame();
    }
}
