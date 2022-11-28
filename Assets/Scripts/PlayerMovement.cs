using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;

    private float moveSpeed = 50f;
    
    private float xAxisInput;
    private float zAxisInput;

    private void FixedUpdate()
    {
        GetPlayerInput();
        MovePlayer();
    }

    private void GetPlayerInput()
    {
        xAxisInput = Input.GetAxisRaw("Horizontal");
        zAxisInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        playerRB.velocity += transform.right * xAxisInput * moveSpeed * Time.fixedDeltaTime + transform.forward * zAxisInput * moveSpeed * Time.fixedDeltaTime;
    }
}
