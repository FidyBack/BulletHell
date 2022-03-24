using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{

	Animator animator;

	private void Start() {
		animator = GetComponent<Animator>();
	}

	public void Shoot()
	{
		throw new System.NotImplementedException();
	}

	public void TakeDamage()
	{
		animator.SetTrigger("Collison");
		// throw new System.NotImplementedException();
	}

	public void Die()
	{
		Destroy(gameObject);
	}

	void FixedUpdate()
	{
		float yInput = Input.GetAxis("Vertical");
		float xInput = Input.GetAxis("Horizontal");
		Thrust(xInput, yInput);

	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Enemys")) {
			Destroy(collision.gameObject);
			TakeDamage();
		}
	}


	
}
