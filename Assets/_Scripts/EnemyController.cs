using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable {

	Animator animator;
	SpriteRenderer Actsprite;
	public GameObject bullet;
	public AudioClip shootSFX, damageSFX;
	private int lifes;

	private void Start() {
		animator = GetComponent<Animator>();
		Actsprite = GetComponent<SpriteRenderer>();
		Actsprite.color = new Color(Actsprite.color.r, Actsprite.color.g, Actsprite.color.b, 1.0f);
		lifes = 5;
	}

	public void Shoot() {
		throw new System.NotImplementedException();
	}

	public void TakeDamage() {
		AudioManager.Play(damageSFX);
		lifes--;
		if (lifes <= 0) {
			// AudioManager.Play(deathSFX);
			Die();
		}
		Actsprite.color = new Color(Actsprite.color.r, Actsprite.color.g, Actsprite.color.b, 0.5f);
		Invoke("ChangeColor", 0.1f);
	}

	public void ChangeColor() {
		Actsprite.color = new Color(Actsprite.color.r, Actsprite.color.g, Actsprite.color.b, 1.0f);
	}

	public void Die() {
		Destroy(gameObject);
	}

	float angle = 0;
	private void FixedUpdate() {
		angle += 0.1f;
		Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
		float x = Mathf.Sin(angle);
		float y = Mathf.Cos(angle);

		Thrust(x, y);
	}
}
