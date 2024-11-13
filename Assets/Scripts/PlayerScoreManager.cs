using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    public int score = 0;
    public int health = 100;
    public int maxHealth = 100;

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0); // Ensure health doesn't go below 0
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            PlayerDeath();
        }
    }

    public void RestoreHealth(int value)
    {
        health += value;
        health = Mathf.Min(health, maxHealth); // Ensure health doesn't exceed maxHealth
        Debug.Log("Health Restored: " + health);
    }

    private void PlayerDeath()
    {
        Debug.Log("Player has died!");
    }
}