using UnityEngine;
using UnityEngine.InputSystem; // Will need to install input system from Package Manager

public class PlayerBrain : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerProfileSO profile;

    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private PlayerSenses senses;

    [Header("State")]
    [SerializeField] private PlayerTraversalState currentState = PlayerTraversalState.Idle;

    [Header("Input Readout")]
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private bool jumpPressed;

    [Header("Velocity Readout")]
    [SerializeField] private Vector3 currentHorizontalVelocity;
    [SerializeField] private float verticalVelocity;

    private void Awake()
    {
        // Cache references if needed.
        // Example: rb = GetComponent<Rigidbody>();
        // Keep setup defensive but simple.
    }

    private void Update()
    {
        // Read input every frame.
        // Run environment checks.
        // Decide which traversal state we should be in.
    }

    private void FixedUpdate()
    {
        // Apply movement in physics step.
        // Handle grounded / walking / airborne movement here.
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Read Vector2 move input from New Input System.
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Detect jump press.
        // Usually set jumpPressed = true when performed.
    }

    private void UpdateState()
    {
        // Decide state transitions.
        // For Session 1:
        // grounded + no move = Idle
        // grounded + move = Walk
        // not grounded = Jump
    }

    private void HandleMovement()
    {
        // Main movement dispatcher.
        // Call the correct movement method based on currentState.
    }

    private void HandleIdle()
    {
        // Slow the player to a stop on the ground.
        // No intended horizontal motion.
    }

    private void HandleWalk()
    {
        // Convert move input into camera-relative movement.
        // Accelerate toward walk speed.
    }

    private void HandleJump()
    {
        // Apply air movement and gravity while airborne.
    }

    private void TryJump()
    {
        // Only allow if grounded in Session 1.
        // Set vertical velocity / apply jump force.
        // Move into Jump state immediately.
    }

    private Vector3 GetCameraRelativeMoveDirection()
    {
        // Convert 2D input into a world direction based on camera forward/right.
        // Ignore camera Y so movement stays planar.
        return Vector3.zero;
    }

    private void ApplyGravity()
    {
        // Reduce vertical velocity over time.
        // Clamp to max fall speed.
    }

    private void ApplyFinalVelocity()
    {
        // Combine horizontal movement and vertical movement.
        // Push result into rigidbody.
    }
}