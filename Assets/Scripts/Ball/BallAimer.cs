using UnityEngine;

public class BallAimer : MonoBehaviour
{
    public Rigidbody ballRigidbody;
    public Transform aimTarget;
    public float flightTime = 0.6f; // Time to reach target

    public void AimAndLaunchBall()
    {
        if (ballRigidbody == null || aimTarget == null) return;

        Vector3 velocity = CalculateVelocity(ballRigidbody.position, aimTarget.position, flightTime);

        // Clamp max velocity for safety
        float maxVelocity = 20f;
        if (velocity.magnitude > maxVelocity)
        {
            Debug.LogWarning("⚠️ Velocity too high! Clamping...");
            velocity = velocity.normalized * maxVelocity;
        }

        Debug.Log("🚀 Launching ball with velocity: " + velocity);

        ballRigidbody.linearVelocity = velocity; 
        ballRigidbody.useGravity = true;
    }

    Vector3 CalculateVelocity(Vector3 startPoint, Vector3 endPoint, float time)
    {
        Vector3 distance = endPoint - startPoint;
        Vector3 distanceXZ = new Vector3(distance.x, 0f, distance.z);

        float horizontalDistance = distanceXZ.magnitude;
        float verticalDistance = distance.y;

        float vXZ = horizontalDistance / time;
        float vY = (verticalDistance / time) + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized * vXZ;
        result.y = vY;

        Debug.Log($"📏 From {startPoint} to {endPoint} | Horizontal: {horizontalDistance:F2}, Vertical: {verticalDistance:F2}, vY: {vY:F2}");

        return result;
    }
}
