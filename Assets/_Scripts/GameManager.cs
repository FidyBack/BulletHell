using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager {

    private static GameManager _instance;
	public int lifes, points;

    public static GameManager GetInstance() {
		if(_instance == null) {
			_instance = new GameManager();
		}

		return _instance;
	}

    private GameManager() {
		lifes = 3;
		points = 0;
	}

    public void Restart() {
		lifes = 3;
		points = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu() {
		lifes = 3;
		points = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
