using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    public int coinValue = 1;

    public void Interact()
    {
        // Directly access PlayerScoreManager through the Singleton instance
        PlayerScoreManager.Instance.AddScore(coinValue);
        Destroy(gameObject); // Destroy the coin after collection
    }
}
