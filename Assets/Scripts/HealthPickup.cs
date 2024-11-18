using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour, IInteractable
{
    public int healthValue = 20;

    public void Interact()
    {
        // Directly access PlayerScoreManager through the Singleton instance
        PlayerScoreManager.Instance.RestoreHealth(healthValue);
        // Debug.Log("Player picked up health: " + healthValue);
        Destroy(gameObject); // Destroy the health pickup after collection
    }
}
