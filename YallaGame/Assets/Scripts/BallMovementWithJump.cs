using UnityEngine;

// This class extends BallMovement and adds jumping capability (keyboard + swipe)
public class BallMovementWithJump : BallMovement
{
    public float jumpForce = 3f; // Force applied when jumping

    private Rigidbody rb; // Rigidbody used for physics-based jumping
    private bool isGrounded = true; // Flag to determine if the ball is on the ground
    private bool jumpRequest = false; // Set to true when a jump is requested
    private Vector2 swipeStart; // Start position of the swipe

    private void Awake()
    {
        // Get the Rigidbody component on this object
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on this GameObject!");
        }
    }

    // Update is called every frame
    protected override void Update()
    {
        // Call the movement logic from the base BallMovement class
        base.Update();

        // Check if a jump was requested via keyboard
        HandleJumpInput();

        // Check if a jump was requested via swipe on touchscreen
        HandleSwipeJump();
    }

    // Checks for keyboard input (Spacebar) to trigger a jump
    private void HandleJumpInput()
    {
        // Only allow jumping if on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
        }
    }

    // Checks for vertical swipe gesture to trigger a jump on mobile
    private void HandleSwipeJump()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // Record the position where the touch begins
            if (touch.phase == TouchPhase.Began)
            {
                swipeStart = touch.position;
            }
            // When the touch ends, check the swipe direction
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeEnd = touch.position;
                Vector2 swipeDelta = swipeEnd - swipeStart;

                // If the swipe is upward and mostly vertical, request a jump
                if (swipeDelta.y > 100f && Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x) && isGrounded)
                {
                    jumpRequest = true;
                }
            }
        }
    }

    // FixedUpdate is called at a fixed time interval and is used for physics updates
    private void FixedUpdate()
    {
        // If a jump was requested, apply upward force to simulate jump
        if (jumpRequest)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // The ball is now in the air
            jumpRequest = false; // Reset the jump request
        }
    }

    // Detect collisions to know when the ball has landed back on the ground
    private void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            // If the collision was from below (e.g., the ground), set isGrounded to true
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }
}
