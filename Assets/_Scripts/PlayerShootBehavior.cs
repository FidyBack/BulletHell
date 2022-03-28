using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehavior : SteerableBehaviour {

    private Vector3 objectSize, bounds;
    

    private void Start() {
		bounds = gameObject.GetComponent<SizeAndCamera>().screenBounds();
		objectSize = gameObject.GetComponent<SizeAndCamera>().objectSize();
    }

    private void Update() {
        if (transform.position.y > bounds.y + objectSize.y) {
			Destroy(gameObject);
		}

        Thrust(0, 1);
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {

        if(collider.CompareTag("Player")) return;

        IDamageable damagable = collider.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damagable is null)) {
            damagable.TakeDamage();
        }
        Destroy(gameObject);
    }
}
