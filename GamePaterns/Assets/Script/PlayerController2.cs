using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController2 : MonoBehaviour
{
    Rigidbody rbComponent;

    public float moveSpeed = 5;
    public float jumpForce = 10; 
    private float horizontalInput = 0;
    private float verticalInput = 0;
    private Vector3 direction;

    void Start()
    {
        rbComponent = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (direction != Vector3.zero)
        {
            rbComponent.velocity = new Vector3(direction.x * moveSpeed, rbComponent.velocity.y, direction.z * moveSpeed);
        }
    }

    public void OnMove(InputValue value)
    {
        var v = value.Get<Vector2>();
        horizontalInput = v.x;
        verticalInput = v.y;
        direction = new Vector3(horizontalInput, 0, verticalInput);
        direction = direction.normalized;
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if (Mathf.Approximately(rbComponent.velocity.y, 0f))// si on est au sol
            {
                rbComponent.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

}