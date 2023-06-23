using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Shoot shoot;

    private Rigidbody2D rigidbodyPlayer;
    private Vector2 inputVector;
    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");

        if (inputVector != Vector2.zero)
        {
            float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
        if(Input.GetKeyDown(KeyCode.Space)) /*&& !isReload)*/
        {
            shoot.CharacterShooting();
        }

    }

    private void FixedUpdate()
    {
        rigidbodyPlayer.MovePosition(rigidbodyPlayer.position + inputVector * moveSpeed * Time.fixedDeltaTime);
    }
}
