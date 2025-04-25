// using UnityEngine;

// public class BallManager : MonoBehaviour
// {
//     public GameObject ballPrefab;
//     public Transform spawnPoint;
//     private GameObject currentBall;

//     void Start()
//     {
//         SpawnNewBall();
//     }

//     public void SpawnNewBall()
//     {
//         currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
//         Rigidbody rb = currentBall.GetComponent<Rigidbody>();
//         rb.useGravity = false;
//     }

//     public GameObject GetCurrentBall()
//     {
//         return currentBall;
//     }

//     public void ResetBall()
//     {
//         if (currentBall != null)
//         {
//             Destroy(currentBall); // destroy old ball
//         }
//         SpawnNewBall(); // spawn new one at the start point
//     }

    
// }

using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;
    private GameObject currentBall;

    void Start()
    {
        SpawnNewBall(onPlayer1Side: true); // default first serve
    }

    public void SpawnNewBall(bool onPlayer1Side)
    {
        if (currentBall != null)
        {
            Destroy(currentBall);
        }

        Transform spawnPoint = onPlayer1Side ? player1SpawnPoint : player2SpawnPoint;
        currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = currentBall.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public GameObject GetCurrentBall()
    {
        return currentBall;
    }

    // Call this when there's no score change (like ball hits net, etc.)
    public void ResetBallToSide(bool onPlayer1Side)
    {
        SpawnNewBall(onPlayer1Side);
    }
}
