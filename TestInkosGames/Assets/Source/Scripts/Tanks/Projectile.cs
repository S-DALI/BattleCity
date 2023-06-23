using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float timeLifeEffect = 2f;
    [SerializeField] protected int damage;

    protected Fragility strength;
    protected void CreateEffect()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, timeLifeEffect);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        strength = collision.gameObject.GetComponent<Fragility>();
        if (strength != null)
            strength.takeDamage(damage);

        CreateEffect();
    }

    
}
