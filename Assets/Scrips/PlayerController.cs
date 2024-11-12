using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    // Variable to store movement direction
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
    }

    // FixedUpdate is used for physics-based movement
    void FixedUpdate()
    {
        // Get the input values
        float moveHorizontal = Input.GetAxis("Horizontal");  // A/D or Left/Right arrow
        float moveVertical = Input.GetAxis("Vertical");      // W/S or Up/Down arrow

        // Create movement direction vector
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);  // Y is kept 0 to prevent vertical movement

        // Apply velocity to the Rigidbody (preserving the Y axis for gravity)
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
    }

    // This function is called when the player collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with is a rock or tree
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Handle what should happen when player collides with an obstacle (rock/tree)
            // You could stop the player's movement or add some other logic here
            Debug.Log("Player collided with " + collision.gameObject.name);

            // Optional: You can stop movement by setting velocity to zero
            rb.velocity = Vector3.zero;  // Stops player movement when colliding with an obstacle
        }
    }

    // Optional: You can also handle continuous collisions with OnCollisionStay
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Keep the player from passing through the obstacle if they are still touching it
            Debug.Log("Player is staying in collision with " + collision.gameObject.name);
        }
    }
}

