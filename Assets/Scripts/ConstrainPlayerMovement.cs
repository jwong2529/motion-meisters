using UnityEngine;

public class ConstrainPlayerMovement : MonoBehaviour
{
    [Header("Movement Constraints")]
    public float minZ = -10.0f;
    public float maxZ = 10.0f;
    public float fixedX = 4.5f;

    [Header("Rotation Constraint")]
    // Player always faces the other side of the table
    public Vector3 fixedEulerAngles = new Vector3(0, 270f, 0);

    void LateUpdate() {
        //Lock position
        Vector3 pos = transform.position;
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        pos.x = fixedX;
        transform.position = pos;

        //Lock rotation
        transform.rotation = Quaternion.Euler(fixedEulerAngles);
    }
}

