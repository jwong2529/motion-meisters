using UnityEngine;

public class CPU : MonoBehaviour
{
    float speed = 40f; // moveSpeed
    Animator animator;
    public Transform ball;
    public Transform aimTarget; // aiming gameObject

    float force = 13f; // ball impact force
    Vector3 targetPosition; // target position for the bot

    Rigidbody rb;

    void Start()
    {
        targetPosition = transform.position; // initialize targetPosition
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move(); // physics-based movement should be in FixedUpdate
    }

    void Move()
{
    // Keep the original Y and Z so the CPU doesn't shift vertically or forward/back.
    targetPosition.y = transform.position.y;
    targetPosition.z = transform.position.z;

    // Follow the ball only on X
    targetPosition.x = ball.position.x;

    transform.position = Vector3.MoveTowards(
        transform.position, 
        targetPosition, 
        speed * Time.deltaTime
    );
}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball2")) // when colliding with the ball
        {
            Vector3 dir = aimTarget.position - transform.position; // direction to aimTarget
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 6, 0); // hit the ball

            Vector3 ballDir = ball.position - transform.position; // determine which way to swing
            if (ballDir.x >= 0)
            {
                animator.Play("forehand");
            }
            else
            {
                animator.Play("backhand");
            }
        }
    }
}
