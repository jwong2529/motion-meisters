using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private int bounceCount = 0;
    private string lastHitBy = "";

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerSide") || collision.gameObject.CompareTag("CPUSide"))
        {
            bounceCount++;

            Debug.Log("Bounced on: " + collision.gameObject.tag);

            if (lastHitBy == "Player" && bounceCount == 1 && collision.gameObject.CompareTag("PlayerSide"))
            {
                Debug.Log("Good: First serve bounce on your side.");
            }
            else if (lastHitBy == "Player" && bounceCount == 2 && collision.gameObject.CompareTag("CPUSide"))
            {
                Debug.Log("Legal serve finished.");
            }
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            lastHitBy = "Player";
            bounceCount = 0;
        }
    }
}
