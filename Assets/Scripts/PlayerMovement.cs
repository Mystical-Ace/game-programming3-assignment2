using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 100f;

    private Rigidbody rb;
    private Transform playerBody;
    private float xRotation = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerBody = transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Handle player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = playerBody.right * moveHorizontal + playerBody.forward * moveVertical;

        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);

        // Handle camera rotation with mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.localRotation = Quaternion.Euler(xRotation, playerBody.localRotation.eulerAngles.y, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}