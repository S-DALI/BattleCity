using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float raycastStrangthDistance = 0.5f;
    [SerializeField] private float raycastFragilityDistance = 3f;
    [SerializeField] private float timeDelayArbitraryRotate=10f;

    [SerializeField] private LayerMask unstrangthLayerMask;
    [SerializeField] private LayerMask fragilityLayerMask;

    [SerializeField] private Shoot shoot;
    private Rigidbody2D rigidBodyEnemy;

    void Start()
    {
        rigidBodyEnemy = GetComponent<Rigidbody2D>();
        StartCoroutine(ArbitraryRotate());
    }

    private void FixedUpdate()
    {
        Vector2 movement = transform.up * speed * Time.fixedDeltaTime;
        RaycastHit2D hitStrangthObstacle = Physics2D.Raycast(shoot.shootingPoint.transform.position, transform.up, raycastStrangthDistance, unstrangthLayerMask);
        RaycastHit2D hitFragilityObstacle = Physics2D.Raycast(transform.position, transform.up, raycastFragilityDistance, fragilityLayerMask);

        if (hitStrangthObstacle)
        {
            Rotate();
        }
        if(hitFragilityObstacle)
        {
            shoot.CharacterShooting();
        }
        rigidBodyEnemy.MovePosition(rigidBodyEnemy.position + movement);
    }

    private void Rotate()
    {
        int randomIndex = Random.Range(0, 2);
        float rotationAmount = randomIndex == 0 ? -90f : 90f;
        transform.Rotate(0f, 0f, rotationAmount);
    }
    private IEnumerator ArbitraryRotate()
    {
        while (true)
        {
            Rotate();
            yield return new WaitForSeconds(timeDelayArbitraryRotate);
        }
    }
}
