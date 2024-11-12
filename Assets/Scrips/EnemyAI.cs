using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;        // Reference to the player's position
    public float attackRange = 2f;  // Distance at which enemy will attack
    public float attackCooldown = 1.5f; // Time between attacks
    public int damage = 10;         // Damage dealt to the player

    private float lastAttackTime = 0f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    public void TakeDamage(int damage)
    {
    // Implement enemy health logic here
    Debug.Log("Enemy took " + damage + " damage.");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // Enemy is within attack range
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            // Move towards the player if out of attack range
            ChasePlayer();
        }
    }
    void ChasePlayer()
    {
        // Simple follow logic (you can expand this for pathfinding)
        transform.position = Vector3.MoveTowards(transform.position, player.position, 2f * Time.deltaTime);
        
        // Face the player
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void AttackPlayer()
    {
        // Play attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Assume the player has a script called "PlayerHealth" with a "TakeDamage" method
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }


    }
}

