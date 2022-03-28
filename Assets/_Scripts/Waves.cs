using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {
	public GameObject[] enemies;
	private Vector3 pos;
	private bool firstWaveDone = false;


	private void Start() {
		pos = transform.position;
		firstWaveEnemiesSpawn();
	}

	private void Update() {
		if (firstWaveDone) {

		}
	}
	
	private void firstWaveEnemiesSpawn() {
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 7; j++) {
				if (i % 2 == 0) {
					Instantiate(enemies[0], new Vector3(pos.x - 0.5f*j, (pos.y + 1.5f*j)+i*10 , pos.z), Quaternion.identity);
				} else{
					Instantiate(enemies[0], new Vector3(pos.x + 0.5f*j, (pos.y + 1.5f*j)+i*10, pos.z), Quaternion.identity);
				}
			}
		}
		firstWaveDone = true;
	}
}
