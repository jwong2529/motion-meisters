using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    private GameObject currentBall;

    void Start()
    {
        SpawnNewBall();
    }

    public void SpawnNewBall()
    {
        currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = currentBall.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public GameObject GetCurrentBall()
    {
        return currentBall;
    }

    public void ResetBall()
    {
        if (currentBall != null)
        {
            Destroy(currentBall); // destroy old ball
        }
        SpawnNewBall(); // spawn new one at the start point
    }

    
}
