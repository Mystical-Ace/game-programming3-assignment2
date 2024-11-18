using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    private float _xRotation = 0f;
    
    private void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Handle camera rotation with mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust vertical rotation based on mouse Y-axis movement
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f); // Clamp to prevent excessive vertical rotation

        // Apply rotation to player body
        transform.localRotation = Quaternion.Euler(_xRotation, transform.localRotation.eulerAngles.y, 0f);

        // Rotate the player object based on horizontal mouse movement
        transform.Rotate(Vector3.up * mouseX);
    }
}
