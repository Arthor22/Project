using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;         // The player's transform (drag player here)
    public float distance = 5f;      // The distance from the player (camera's distance behind player)
    public float height = 2f;        // Height offset for the camera (how high above the player it is)
    public float rotationSpeed = 5f; // How fast the camera rotates around the player

    private float currentRotation = 0f; // The current rotation of the camera around the player

    void Update()
    {
        // Rotate the camera with the player based on input (left-right rotation)
        float horizontalInput = Input.GetAxis("Horizontal");
        currentRotation += horizontalInput * rotationSpeed * Time.deltaTime;

        // Update the camera's position and rotation
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        // Calculate the desired position of the camera
        Vector3 offset = new Vector3(0, height, -distance);  // Offset from player
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);  // Rotation around the Y-axis
        transform.position = player.position + rotation * offset;  // Apply the rotation to the offset

        // Make the camera always look at the player
        transform.LookAt(player.position);
    }
}