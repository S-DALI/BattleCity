using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileForce = 10f;
    [SerializeField] private float reloadingTime=1f;

    private bool isReload;

    public void CharacterShooting()
    {
        if(!isReload)
        {
            StartCoroutine(Shooting());
        }
    }
    private IEnumerator Shooting() 
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody2D projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidBody.AddForce(shootingPoint.up * projectileForce, ForceMode2D.Impulse);
        isReload= true;
        yield return new WaitForSeconds(reloadingTime);
        isReload= false;
    }
}
