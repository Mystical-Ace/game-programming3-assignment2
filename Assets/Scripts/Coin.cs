using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    // Coin value to add to the player's score
    [SerializeField] private int coinValue = 1;

    // This method is called when the player interacts with the coin
    public void Interact()
    {
        // Directly access PlayerScoreManager through the Singleton instance
        PlayerScoreManager.Instance.AddScore(coinValue);

        // Destroy the coin after collection
        Destroy(gameObject);
    }
}
