using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;

        // Move the player character using Rigidbody to ensure physics accuracy
        _rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}
