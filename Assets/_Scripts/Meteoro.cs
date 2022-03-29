using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer Actsprite;

    public AudioClip damageSFX;

    public float ySpeed;
    public float healt;

    private Vector3 objectSize, bounds;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healt = 20;
        bounds = gameObject.GetComponent<SizeAndCamera>().screenBounds();
		    objectSize = gameObject.GetComponent<SizeAndCamera>().objectSize();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, ySpeed*-1);
    }

    private void FixedUpdate() {
		if (transform.position.y < -(bounds.y + objectSize.y)) {
			Die();
		}
    }
    
    public void TakeDamage() {
      healt--;
      AudioManager.Play(damageSFX);
      if (healt <= 0) {
        Die();
      }
	}

    public void Die() {
		Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Shoot")) {
			Destroy(collision.gameObject);
			TakeDamage();
		}
	} 
}
