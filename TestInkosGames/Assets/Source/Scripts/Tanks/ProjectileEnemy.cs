using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        strength = collision.gameObject.GetComponent<Fragility>();
        if (strength != null)
            strength.takeDamage(damage);

        CreateEffect();
    }
}
