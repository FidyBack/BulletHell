using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable {

	Animator animator;
	SpriteRenderer sprite;
	public GameObject bullet;

	[SerializeField]
	private Sprite[] spriteDamage;

	private int lifes;

	private void Start() {
		animator = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
		lifes = 5;
	}


	public void Shoot() {
		throw new System.NotImplementedException();
	}

	public void TakeDamage() {
		// animator.SetTrigger("Collison");
		// AudioManager.Play(damageSFX);
		lifes--;
		string spriteName = "Tilt" + GetComponent<SpriteRenderer>().sprite.name;

		foreach (Sprite s in spriteDamage) {
			if (s.name == spriteName) {
				sprite.sprite = s;
				break;
			}
		}

		if (lifes <= 0) {
			// AudioManager.Stop(Background);
			// AudioManager.Play(deathSFX);
			Die();
		}
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
