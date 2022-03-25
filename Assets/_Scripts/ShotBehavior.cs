using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehavior : SteerableBehaviour
{

    private void Update() {
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
