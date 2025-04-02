using UnityEngine;

public class BallServe : MonoBehaviour
{
    public GameObject handObject;
    public Rigidbody ballRb;
    public float tossForce = 3f; // this was 3f
    private bool isHeld = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.SetParent(handObject.transform);
        ballRb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld && handObject.transform.position.y > 1.2f) { //used to be 1.2
            ReleaseBall();
        }
    }

    void ReleaseBall() {
        isHeld = false;
        transform.SetParent(null);
        ballRb.isKinematic = false;
        ballRb.AddForce(Vector3.up * tossForce, ForceMode.Impulse);
        Debug.Log("Ball tossed!");
    }
}
