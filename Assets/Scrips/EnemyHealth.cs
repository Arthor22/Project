using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;          // Maximum health of the enemy
    public int currentHealth;            // Current health of the enemy

    public HealthBar healthBar;          // Reference to the enemy health bar (if you have one)

    void Start()
    {
        currentHealth = maxHealth;      // Set the starting health to the max health
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);   // Initialize health bar if it exists
        }
    }

    // Function to deal damage to the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                // Decrease health by the damage amount

        // Ensure health doesn't go below 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the health bar if it exists
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        // Check if the enemy is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Function to handle enemy death
    void Die()
    {
        // Optionally, play death animations or effects here
        Destroy(gameObject);   // Destroy the enemy object when its health reaches 0
    }
}
