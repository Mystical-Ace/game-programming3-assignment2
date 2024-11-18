using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    // Reference to the door controlled by this switch
    [SerializeField] private DoorController door;

    // Tracks whether the player is in range of the switch to allow interaction
    private bool playerInRange = false;

    // Tracks if interaction has been allowed (to avoid unintended triggers)
    private bool interactionAllowed = false;

    private void Start()
    {
        // Ensure interaction is not allowed until explicitly triggered
        interactionAllowed = false;
    }

    private void Update()
    {
        // Check if the player is in range and presses the "E" key to interact with the switch
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            interactionAllowed = true; // Explicitly allow interaction after key press
            Interact(); // Call the Interact method explicitly when the "E" key is pressed
        }
    }

    // Implement the required Interact method from IInteractable
    public void Interact()
    {
        // Defensive check: Only interact if interaction is allowed explicitly by pressing "E"
        if (!interactionAllowed)
        {
            Debug.LogWarning("Interact called, but interaction not explicitly allowed. Aborting.");
            return; // Abort if interactionAllowed is false
        }

        if (door != null)
        {
            Debug.Log("Toggling door...");
            door.ToggleDoor(); // Toggle the door's state
            interactionAllowed = false; // Reset interaction flag after toggling the door
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the player enters the trigger area, set playerInRange to true
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When the player leaves the trigger area, set playerInRange to false
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionAllowed = false; // Reset interaction flag when the player leaves
        }
    }
}
