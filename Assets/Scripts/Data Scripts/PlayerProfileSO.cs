using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProfile_", menuName = "Game/Player Profile")]
public class PlayerProfileSO : ScriptableObject // This is just the movement variables of a given player profile
{
    // We can make/test different player profiles and inject them at run time
    // This should allow us to A/B test different setups
    // Keep it simple for our first session, you'll add variables for running/crouching/wallslide for homework etc

    [Header("Ground Movement")]
    public float walkSpeed = 5f;
    public float groundAcceleration = 20f;
    public float groundDeceleration = 25f;

    [Header("Air Movement")]
    public float airAcceleration = 10f;
    public float maxAirSpeed = 5f;

    [Header("Jump")]
    public float jumpForce = 8f;
    public float gravity = -25f;
    public float maxFallSpeed = -20f;

    [Header("Checks")]
    public float groundCheckDistance = 0.2f;
    public float wallCheckDistance = 0.4f;
}
