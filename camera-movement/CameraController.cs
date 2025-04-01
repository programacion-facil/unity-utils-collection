/*
 * This script allows the player to control the camera's position and rotation in a 3D space using keyboard
 * inputs for movement and mouse inputs for rotation. 
 *
 * Movement:
 * - The camera moves based on the horizontal (A/D or Left/Right Arrow) and vertical (W/S or Up/Down Arrow) inputs.
 * - The speed of movement is controlled by the "speed" variable.
 * 
 * Rotation:
 * - The camera rotates based on the movement of the mouse.
 * - Mouse movement along the Y-axis (up/down) controls the camera's X-axis rotation (pitch).
 * - Mouse movement along the X-axis (left/right) controls the camera's Y-axis rotation (yaw).
 * - Rotation is clamped on the X-axis to prevent the camera from rotating too far up or down (beyond -90° and 90°).
 */

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10f;  // Movement speed
    public float sensitivity = 2f;  // Mouse sensitivity

    private float rotationX = 0f;  // Camera X rotation
    private float rotationY = 0f;  // Camera Y rotation

    void Update()
    {
        // Movement with WASD keys
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Move the camera in space
        transform.Translate(horizontal, 0f, vertical);

        // Camera movement with the mouse
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY += Input.GetAxis("Mouse X") * sensitivity;

        // Limit X rotation (to avoid extreme rotations)
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Apply the rotation
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
