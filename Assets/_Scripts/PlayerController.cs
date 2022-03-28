// O script que evita que o jogador saia do mapa foi feito baseado neste tutorial: https://www.youtube.com/watch?v=ailbszpt_AI

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable {

	Animator animator;

	public GameObject bullet;
	public AudioClip shootSFX, damageSFX, deathSFX, Background;
	public Transform[] gun;
	public float shootDelay = 0.1f;

	private Vector3 objectSize, bounds;
	private int lifes;
	private float _lastShootTimestamp = 0.0f;

	private void Start() {
		bounds = gameObject.GetComponent<SizeAndCamera>().screenBounds();
		objectSize = gameObject.GetComponent<SizeAndCamera>().objectSize();
		animator = GetComponent<Animator>();
		lifes = 5;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Enemys")) {
			Destroy(collision.gameObject);
			TakeDamage();
		}
	}

	public void Shoot() {
		if (Time.time - _lastShootTimestamp < shootDelay) return;

		AudioManager.Play(shootSFX);
		_lastShootTimestamp = Time.time;
		foreach (Transform gunPoint in gun) {
			Instantiate(bullet, gunPoint.position, Quaternion.identity);
		}
	}

	public void TakeDamage() {
		animator.SetTrigger("Collison");
		AudioManager.Play(damageSFX);
		lifes--;
		if (lifes <= 0) {
			AudioManager.Stop(Background);
			AudioManager.Play(deathSFX);
			Die();
		}
	}

	public void Die() {
		Destroy(gameObject);
	}

	void FixedUpdate() {
		float yInput = Input.GetAxis("Vertical");
		float xInput = Input.GetAxis("Horizontal");

		if (xInput < 0) {
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 5));
		} else if (xInput > 0) {
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, -5));
		} else {
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}

		if (Input.GetKey(KeyCode.Space)) {
			Shoot();
		}

		Thrust(xInput, yInput);
	}

	void LateUpdate(){
		Vector3 viewPos = transform.position;
		viewPos.x = Mathf.Clamp(viewPos.x, -(bounds.x - objectSize.x), bounds.x - objectSize.x);
		viewPos.y = Mathf.Clamp(viewPos.y, -(bounds.y - objectSize.y), bounds.y - objectSize.y);
		transform.position = viewPos;
	}
}
