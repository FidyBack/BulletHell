using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{

	Animator animator;
	public GameObject bullet;
	public AudioClip shootSFX, damageSFX, deathSFX, Background;
	public Transform gun;

	private int lifes;
	public float shootDelay = 0.1f;
	private float _lastShootTimestamp = 0.0f;

	private void Start() {
		animator = GetComponent<Animator>();
		lifes = 5;
	}

	public void Shoot() {
		if (Time.time - _lastShootTimestamp < shootDelay) return;

		AudioManager.Play(shootSFX);
		_lastShootTimestamp = Time.time;
		Instantiate(bullet, gun.position, Quaternion.identity);

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
		Thrust(xInput, yInput);

		if (Input.GetAxis("Jump") != 0) {
			Shoot();
		}

	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Enemys")) {
			Destroy(collision.gameObject);
			TakeDamage();
		}
	}
}
