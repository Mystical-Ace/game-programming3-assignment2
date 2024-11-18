using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IInteractable
{
    // Amount of damage the trap deals to the player when triggered
    [SerializeField] private int damageValue = 10;

    // This method is called when the player interacts 
    public void Interact()
    {
        // Directly access PlayerScoreManager through the Singleton instance
        PlayerScoreManager.Instance.TakeDamage(damageValue);

        // Debug.Log("Player triggered a trap: - " + damageValue);
    }
}
