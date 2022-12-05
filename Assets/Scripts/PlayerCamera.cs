using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;

    private float sensX = 1000f;
    private float sensY = 1000f;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        playerTrans.Rotate(Vector3.up * mouseX);
        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y + 0.75f, playerTrans.position.z);
    }
}
