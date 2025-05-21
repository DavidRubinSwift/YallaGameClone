using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Reference to player settings scriptable object
    public PlayerSettings _PlayerSettings;

    // Object that will visually rotate to simulate ball rolling
    public GameObject graficRotation;

    // Forward and sideways movement speed
    private float moveSpeed;
    private float sideSpeed;

    // Horizontal movement boundaries
    private float minX = -1.4f;
    private float maxX = 1.4f;

    // Acceleration when pressing up/down input
    private float acceleration = 4f;

    // Limits for forward movement speed
    private float maxSpeed = 7f;
    private float minSpeed = 2f;

    // Gyroscope reference
    private Gyroscope gyro;

    // Flag to check if gyroscope is available on the device
    private bool gyroAvailable;

    private void Start()
    {
        // Initialize movement speeds from settings
        moveSpeed = _PlayerSettings.playerMoveSpeed;
        sideSpeed = _PlayerSettings.playerSideSpeed;

        // Enable gyroscope if the device supports it
        gyroAvailable = SystemInfo.supportsGyroscope;
        if (gyroAvailable)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleMovement();
    }

    // Handles ball movement and visual rotation
    private void HandleMovement()
    {
        // Get vertical input (W/S or Up/Down arrows)
        float vertical = Input.GetAxis("Vertical");

        // Adjust forward movement speed based on input and acceleration
        moveSpeed += vertical * acceleration * Time.deltaTime;

        // Clamp the forward speed to stay within min and max values
        moveSpeed = Mathf.Clamp(moveSpeed, minSpeed, maxSpeed);

        // Calculate forward movement vector
        Vector3 forwardMove = Vector3.forward * moveSpeed * Time.deltaTime;

        // Get horizontal input (A/D or Left/Right arrows)
        float horizontal = Input.GetAxis("Horizontal");

        // Add tilt input from gyroscope if available
        if (gyroAvailable)
        {
            float tilt = gyro.rotationRateUnbiased.y;
            horizontal += tilt * 0.5f; // scale tilt influence
        }

        // Calculate sideways movement vector
        Vector3 sideMove = Vector3.right * horizontal * sideSpeed * Time.deltaTime;

        // Combine forward and sideways movement
        Vector3 move = forwardMove + sideMove;
        Vector3 newPosition = transform.position + move;

        // Clamp new X position to stay within boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Apply new position to the ball
        transform.position = newPosition;

        // Rotate the visual ball object in the direction of movement
        if (move != Vector3.zero)
        {
            // Determine the rotation axis based on movement direction
            Vector3 rotationAxis = Vector3.Cross(move.normalized, Vector3.up);

            // Calculate movement distance
            float distance = move.magnitude;

            // Get the radius of the ball (assuming sphere)
            float radius = transform.localScale.x * 0.5f;

            // Calculate the angle of rotation based on distance and radius
            float angle = -((distance / (2 * Mathf.PI * radius)) * 360f) * 0.5f;

            // Apply the rotation to the graphical ball object
            graficRotation.transform.Rotate(rotationAxis, angle, Space.World);
        }
    }
}
