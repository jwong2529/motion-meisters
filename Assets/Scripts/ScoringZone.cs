// using UnityEngine;

// public class ScoringZone : MonoBehaviour
// {
//     public enum Side { Player1, Player2 }
//     public Side zoneOwner;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Ball"))
//         {
//             if (zoneOwner == Side.Player1)
//             {
//                 Debug.Log("Ball hit Player 1's side — Player 2 scores!");
//                 FindFirstObjectByType<ScoreManager>()?.Player2Scored();
//             }
//             else
//             {
//                 Debug.Log("Ball hit Player 2's side — Player 1 scores!");
//                 FindFirstObjectByType<ScoreManager>()?.Player1Scored();
//             }

//             Destroy(other.gameObject); // remove the ball
//             FindFirstObjectByType<BallManager>()?.ResetBall(); // spawn a new one
//         }
//     }
// }

using UnityEngine;

public class ScoringZone : MonoBehaviour
{
    public enum Side { Player1, Player2 }
    public Side zoneOwner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallManager ballManager = FindFirstObjectByType<BallManager>();
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

            if (zoneOwner == Side.Player1)
            {
                Debug.Log("Ball hit Player 1's side — Player 2 scores!");
                scoreManager?.Player2Scored();
                ballManager?.SpawnNewBall(onPlayer1Side: true); // Player 1 lost, serve to them
            }
            else
            {
                Debug.Log("Ball hit Player 2's side — Player 1 scores!");
                scoreManager?.Player1Scored();
                ballManager?.SpawnNewBall(onPlayer1Side: false); // Player 2 lost, serve to them
            }

            Destroy(other.gameObject); // destroy the old ball
        }
    }
}
