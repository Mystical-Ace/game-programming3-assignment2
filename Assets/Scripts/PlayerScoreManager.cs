using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    // Singleton instance
    public static PlayerScoreManager Instance { get; private set; }
    
    [SerializeField] private int score = 0;
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;

    private void Awake()
    {
        // Singleton setup: Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure the instance persists between scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }
    }

    // Adds a value to the player's score
    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
    }

    // Reduces player's health by the given damage value
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

    // Restores the player's health by a given value, clamped to maxHealth
    public void RestoreHealth(int value)
    {
        health += value;
        health = Mathf.Min(health, maxHealth); // Ensure health doesn't exceed maxHealth
        Debug.Log("Health Restored: " + health);
    }

    // This would handle the player's death
    private void PlayerDeath()
    {
        Debug.Log("Player has died!");
    }

    // Public read-only properties to access health and sroe
    public int Score => score;
    public int Health => health;
    public int MaxHealth => maxHealth;
}