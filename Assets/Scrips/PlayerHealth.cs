using UnityEngine;
using UnityEngine.UI; // For UI components like Slider

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;                // Maximum health of the player
    public int currentHealth;                  // Current health of the player
    public Slider healthBar;                   // The Slider UI component (health bar)

    void Start()
    {
        // Set the current health to max health at the start
        currentHealth = maxHealth;

        // Initialize the health bar
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;    // Set the slider's max value to the max health
            healthBar.value = currentHealth;   // Set the slider's current value to the current health
        }
    }

    void Update()
    {
        // If you want to test health decrease, you can use keys (just for debugging).
        if (Input.GetKeyDown(KeyCode.H)) // Press H to decrease health
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce health by the damage amount
        currentHealth -= damage;

        // Ensure health doesn't go below 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the health bar's value
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        // Check if health is 0 (player dies)
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death (e.g., play death animation, restart level, etc.)
        Debug.Log("Player has died!");
        // You can trigger a death animation or other behaviors here
    }
}
