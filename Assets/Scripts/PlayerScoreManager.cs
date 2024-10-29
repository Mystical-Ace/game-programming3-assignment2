using UnityEngine;
using TMPro;

public class PlayerScoreManager : MonoBehaviour
{
    public int score = 0;
    public int health = 100;
    public TMP_Text scoreText;
    public TMP_Text healthText;

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateUI();
        Debug.Log("Score: " + score);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0); // Ensure health doesn't go below 0
        UpdateUI();
        Debug.Log("Health: " + health);
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }
}