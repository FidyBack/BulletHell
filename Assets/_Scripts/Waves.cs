using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {
	public GameObject[] enemies;
	private Vector3 pos;
	private bool firstWaveDone, secondWaveDone = false;


	private void Start() {
		pos = transform.position;
		firstWaveEnemiesSpawn();
	}

	private void Update() {
		if (firstWaveDone) {
			secondWaveEnemiesSpawn();
		}else if(secondWaveDone){
			secondWaveDone = false;
		}
	}
	
	private void firstWaveEnemiesSpawn() {
		for (int i = 0; i < 20; i++) {
			for (int j = 0; j < 30; j++) {
				if (i % 2 == 0) {
					Instantiate(enemies[0], new Vector3(pos.x - 0.5f*j, (pos.y + 1.5f*j)+i*10 , pos.z), Quaternion.identity);

					if(j%3 == 0){
						Instantiate(enemies[1], new Vector3(pos.x - 0.5f*j, (pos.y + 1.5f*j)+i*10 , pos.z), Quaternion.identity);
					}

				} else{
					Instantiate(enemies[0], new Vector3(pos.x + 0.5f*j, (pos.y + 1.5f*j)+i*10, pos.z), Quaternion.identity);

					if(j%2 == 0){
						Instantiate(enemies[1], new Vector3(pos.x + 0.5f*j, (pos.y + 1.5f*j)+i*10, pos.z), Quaternion.identity);
					}
				}
			}
		}
		firstWaveDone = true;
	}

	private void secondWaveEnemiesSpawn() {
		for (int i = 0; i < 20; i++) {
			for (int j = 0; j < 30; j++) {
				if (i % 5 == 0) {
					Instantiate(enemies[2], new Vector3(pos.x - 2.5f*j, (pos.y + 3.5f*j)+i*10 , pos.z), Quaternion.identity);
					}

				else if (i % 5 == 1) {
					Instantiate(enemies[2], new Vector3(pos.x + 2.5f*j, (pos.y + 3.5f*j)+i*10 , pos.z), Quaternion.identity);
					}
				}
			}

		firstWaveDone = false;
		secondWaveDone = true;
	}

}
