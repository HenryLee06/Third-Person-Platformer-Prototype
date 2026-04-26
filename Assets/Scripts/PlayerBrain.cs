using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Transform cameraTransform;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Camera Settings")]
    [SerializeField] private float lookSensitivity = 0.1f;
    [SerializeField] private float cameraPitchMin = -30f;
    [SerializeField] private float cameraPitchMax = 60f;

    [Header("State")]
    [SerializeField] private PlayerTraversalState currentState = PlayerTraversalState.Idle;

    [Header("Input Readout")]
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 lookInput;

    [Header("Camera Readout")]
    [SerializeField] private float yaw;
    [SerializeField] private float pitch;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        if (rb != null)
        {
            rb.freezeRotation = true;
        }

        if (cameraPivot != null)
        {
            yaw = cameraPivot.eulerAngles.y;
        }
        else
        {
            yaw = transform.eulerAngles.y;
        }
    }

    private void Update()
    {
        UpdateState();
        HandleCameraRotation();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    private void UpdateState()
    {
        if (moveInput.sqrMagnitude > 0.01f)
        {
            currentState = PlayerTraversalState.Walk;
        }
        else
        {
            currentState = PlayerTraversalState.Idle;
        }
    }

    private void HandleMovement()
    {
        if (rb == null) return;

        Vector3 moveDirection = GetCameraRelativeMoveDirection();

        Vector3 targetVelocity = moveDirection * moveSpeed;

        targetVelocity.y = rb.velocity.y;

        rb.velocity = targetVelocity;

        if (currentState == PlayerTraversalState.Walk && moveDirection.sqrMagnitude > 0.001f)
        {
            transform.forward = Vector3.Lerp(
                transform.forward,
                moveDirection,
                rotationSpeed * Time.fixedDeltaTime
            );
        }
    }

}