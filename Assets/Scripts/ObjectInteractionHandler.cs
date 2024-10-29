using UnityEngine;

public class ObjectInteractionHandler : MonoBehaviour
{
    public int coinValue = 1; // Value for the coins
    public int damageValue = 10; // Damage value for traps

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScoreManager playerScoreManager = other.GetComponent<PlayerScoreManager>();
            if (playerScoreManager == null)
            {
                return; // If there is no PlayerScoreManager, no need to proceed
            }

            // Handle different type of interactions based on tag
            if (CompareTag("Coin"))
            {
                playerScoreManager.AddScore(coinValue);
                Destroy(gameObject); // Destroy the coin after collection
            }
            else if (CompareTag("Trap"))
            {
                playerScoreManager.TakeDamage(damageValue);
            }
        }
    }
}