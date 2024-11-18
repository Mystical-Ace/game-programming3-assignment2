using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float openPositionY = 5.0f; // The amount to raise the door when it opnes
    [SerializeField] private float doorSpeed = 2.0f; // Speed at which the door moves

    private Vector3 closedPosition; // The original position when the door is closed
    private Vector3 openPosition; // The target position for the door when open

    private bool isOpen = false; // Tracks whether the door is open or closed

    private void Start()
    {
        // Set the closed position as the initial position of the door
        closedPosition = transform.position;

        // Calculate the open position based on the desired vertical movement
        openPosition = new Vector3(closedPosition.x, closedPosition.y + openPositionY, closedPosition.z);
    }


    // Toggles the state of the door between open and closed
    public void ToggleDoor()
    {
        // Toggle the isOpen state
        isOpen = !isOpen;

        // Determine the target position based on the door's state
        Vector3 targetPosition = isOpen ? openPosition : closedPosition;

        // Start the coroutine to move the door smoothly to the target position
        StartCoroutine(MoveDoor(targetPosition));
    }

    // Moves the door to the specified target position smoothly
    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        // Move towards the target position until it's close enough
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            // Move the door towards the target position with a given speed
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, doorSpeed * Time.deltaTime);

            // Yield until the next frame
            yield return null;
        }

        // Ensure the final position is set precisely to the target position
        transform.position = targetPosition;
    }
}
