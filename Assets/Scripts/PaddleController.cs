using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float hitForce = 5f; //Adjust power of the hit

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();

            // Apply force based on the paddle's movement
            Vector3 hitDirection = collision.contacts[0].point - transform.position;
            hitDirection = hitDirection.normalized;

            ballRb.AddForce(hitDirection * hitForce, ForceMode.Impulse);
            Debug.Log("Hit the ball!");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball")) {
            Rigidbody ballRb = other.GetComponent<Rigidbody>();

            Vector3 hitDirection = transform.forward;
            float hitStrength = 6f;

            ballRb.AddForce(hitDirection * hitStrength, ForceMode.Impulse);
            Debug.Log("Ball Served!");
        }
    }
}
