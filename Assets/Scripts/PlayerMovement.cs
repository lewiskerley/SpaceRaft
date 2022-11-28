using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRB;

    private float moveSpeed = 5000f;
    
    private float xAxisInput;
    private float zAxisInput;

    private void Update()
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
        playerRB.velocity = new Vector3(xAxisInput * moveSpeed * Time.deltaTime, playerRB.velocity.y, zAxisInput * moveSpeed * Time.deltaTime);
    }
}
