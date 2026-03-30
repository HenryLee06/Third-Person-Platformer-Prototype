using UnityEngine;

public class PlayerSenses : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Transform wallCheckPoint;

    [Header("Layers")]
    [SerializeField] private LayerMask terrainLayer;

    [Header("Debug Readouts")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool touchingWallLeft;
    [SerializeField] private bool touchingWallRight;

    public bool IsGrounded => isGrounded;
    public bool TouchingWallLeft => touchingWallLeft;
    public bool TouchingWallRight => touchingWallRight;

    public void RunChecks(PlayerProfileSO profile)
    {
        // Main entry point called by PlayerBrain each frame.
        // Runs all environment tests we currently care about.
    }

    private void CheckGround(PlayerProfileSO profile)
    {
        // Use a raycast or spherecast downward from groundCheckPoint.
        // Update isGrounded based on whether we detect valid ground.
    }

    private void CheckWalls(PlayerProfileSO profile)
    {
        // Cast left and right from wallCheckPoint.
        // Update touchingWallLeft / touchingWallRight.
    }

    private void OnDrawGizmosSelected()
    {
        // Draw ground and wall check lines so students can see the probes.
    }
}