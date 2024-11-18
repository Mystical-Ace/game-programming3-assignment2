using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour, IInteractable
{
    // Amount of health to restore when picked up
    [SerializeField] private int healthValue = 20;

    // This method is called when the player interacts with the health pickup
    public void Interact()
    {
        // Directly access PlayerScoreManager through the Singleton instance
        PlayerScoreManager.Instance.RestoreHealth(healthValue);

        // Debug.Log("Player picked up health: " + healthValue);

        // Destroy the health pickup after collection
        Destroy(gameObject); 
    }
}
