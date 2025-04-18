using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Ball hit the floor. Respawning...");

            BallManager manager = FindObjectOfType<BallManager>();
            if (manager != null)
            {
                manager.ResetBall();
            }

            Destroy(gameObject); // Clean up the current ball
        }
    }
}
