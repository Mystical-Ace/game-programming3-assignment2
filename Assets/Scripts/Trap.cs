using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IInteractable
{
    public int damageValue = 10;

    public void Interact()
    {
        // Directly access PlayerScoreManager through the Singleton instance
        PlayerScoreManager.Instance.TakeDamage(damageValue);
        // Debug.Log("Player triggered a trap: - " + damageValue);
    }
}
