using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform aimTarget; // Assign the aim target in the Inspector.
    public float hitForce = 15f;  // Adjust this value to control how far/fast the ball is hit.

    Vector3 initialPos; // Ball's initial position

    private void Start()
    {
        initialPos = transform.position; // Store the starting position
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Paddle"))
        {
            // Calculate the direction from the ball to the aimTarget.
            Vector3 direction = (aimTarget.position - transform.position).normalized;
            
            // Get the ball's Rigidbody and apply the new velocity.
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * hitForce;
            }
        }
        // Optionally, you can add additional behavior for other collisions.
        else if (collision.transform.CompareTag("Floor"))
        {
            // For example, reset the ball when it hits a wall.
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
            transform.position = initialPos;
        }
    }
}
