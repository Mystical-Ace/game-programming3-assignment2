using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class ObjectInteractionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with an interactable object
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            // Call the interact method on the interactable object
                interactable.Interact();
            
        }
    }
}