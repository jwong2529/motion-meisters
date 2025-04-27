using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Ball hit the floor. Destroying ball (no score)");

            Destroy(gameObject);

            // Optional fallback if needed
            // FindFirstObjectByType<BallManager>()?.ResetBallToSide(onPlayer1Side: true);
        }
    }
}
