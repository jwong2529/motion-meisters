using UnityEngine;

public class BallController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    private Rigidbody rb;
    public float hitForceMultiplayer = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Hit(Vector3 hitForce) {
        // Reset velocity before applying force
        rb.velocity = Vector3.zero;
        rb.AddForce(hitForce * hitForceMultiplayer, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Table")) {
            Debug.Log("Ball hit the table!");
        }
        if (collision.gameObject.CompareTag("CPU")) {
            Debug.Log("Ball hit the CPU player!");
        }
    }
}
