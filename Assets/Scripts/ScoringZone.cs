using UnityEngine;

public class ScoringZone : MonoBehaviour
{
    public enum Side { Player1, Player2 }
    public Side zoneOwner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (zoneOwner == Side.Player1)
            {
                Debug.Log("Ball hit Player 1's side — Player 2 scores!");
                FindFirstObjectByType<ScoreManager>()?.Player2Scored();
            }
            else
            {
                Debug.Log("Ball hit Player 2's side — Player 1 scores!");
                FindFirstObjectByType<ScoreManager>()?.Player1Scored();
            }

            Destroy(other.gameObject); // remove the ball
            FindFirstObjectByType<BallManager>()?.ResetBall(); // spawn a new one
        }
    }
}
