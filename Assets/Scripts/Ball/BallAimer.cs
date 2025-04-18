using UnityEngine;

public class BallAimer : MonoBehaviour
{
    public Transform aimTarget;
    public float flightTime = 0.6f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 velocity = CalculateVelocity(collision.transform.position, aimTarget.position, flightTime);
                rb.linearVelocity = velocity;
                rb.useGravity = true;
            }
        }

    }

    Vector3 CalculateVelocity(Vector3 start, Vector3 end, float time)
    {
        Vector3 distance = end - start;
        Vector3 distanceXZ = new Vector3(distance.x, 0, distance.z);

        float xz = distanceXZ.magnitude;
        float y = distance.y;

        float vXZ = xz / time;
        float vY = y / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized * vXZ;
        result.y = vY;
        return result;
    }
}
