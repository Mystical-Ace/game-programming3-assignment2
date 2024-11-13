using UnityEngine;

public class ObjectInteractionHandler : MonoBehaviour
{
    public int coinValue = 1; // Value for the coins
    public int damageValue = 10; // Damage value for traps
    public int healthValue = 20; // Value for health pickups

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScoreManager playerScoreManager = other.GetComponent<PlayerScoreManager>();
            if (playerScoreManager == null)
            {
                return; // If there is no PlayerScoreManager, no need to proceed
            }

            // Debug.Log("Player collided with: " + gameObject.tag);

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
            else if (CompareTag("HealthPickup"))
            {
                playerScoreManager.RestoreHealth(healthValue);
                // Debug.Log("Picked up");
                Destroy(gameObject);
            }
        }
    }
}