using UnityEngine;

public class PlayerBallHitter : MonoBehaviour
{
    public Transform rightHand;
    public BallAimer ballAimer;
    public BallManager ballManager;
    public float swingThreshold = 0.4f; // Lower threshold for easier testing

    private Vector3 lastRightHandPos;

    void Update()
    {
        if (rightHand == null || ballManager == null || ballAimer == null)
        {
            Debug.LogWarning("Missing reference on PlayerBallHitter");
            return;
        }

        Vector3 velocity = (rightHand.position - lastRightHandPos) / Time.deltaTime;
        float speed = velocity.magnitude;
        GameObject ball = ballManager.GetCurrentBall();

        if (ball != null)
        {
            float distance = Vector3.Distance(rightHand.position, ball.transform.position);
            // Debug.Log($"[Swing] Speed: {speed:F2}, Ball Distance: {distance:F2}");

            if (speed > swingThreshold && distance < 0.6f)
            {
                Debug.Log("✅ HIT DETECTED!");
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                ballAimer.ballRigidbody = rb;
                ballAimer.AimAndLaunchBall();
            }
        }

        lastRightHandPos = rightHand.position;
    }
}
