using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 20;               // Damage dealt to the enemy
    public float attackRange = 2f;              // Attack range
    public float attackCooldown = 1f;           // Cooldown between attacks
    public LayerMask enemyLayer;                // Layer for detecting enemies

    private Animator animator;
    private float lastAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();    // Reference to the Animator component
    }

    void Update()
    {
        // Check if Spacebar is pressed and if attack is off cooldown
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        // Play attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Detect enemies in range of the attack
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        // Damage each enemy hit
        foreach (Collider enemy in hitEnemies)
        {
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.TakeDamage(attackDamage);  // Call TakeDamage method on the enemy
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw attack range for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

