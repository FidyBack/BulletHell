using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable {

	Animator animator;
	SpriteRenderer Actsprite;

	public GameObject bullet;
	public AudioClip shootSFX, damageSFX;

	private Vector3 objectSize, bounds;
	private int lifes;

	private void Start() {
		animator = GetComponent<Animator>();
		Actsprite = GetComponent<SpriteRenderer>();
		bounds = gameObject.GetComponent<SizeAndCamera>().screenBounds();
		objectSize = gameObject.GetComponent<SizeAndCamera>().objectSize();
		lifes = 2;
	}

	private void FixedUpdate() {
		if (transform.position.y < -(bounds.y + objectSize.y)) {
			Die();
		}

		Thrust(0, -1);
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
}
