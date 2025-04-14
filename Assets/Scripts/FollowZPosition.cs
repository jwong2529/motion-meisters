using UnityEngine;

public class FollowZPosition : MonoBehaviour
{
    public Transform targetToFollow;
    public float x = -1.3f; // player side of table
    public float y = 2.0f; // table height
    public float minZ = -2.0f; //left limit
    public float maxZ= 2.0f; // right limit

    void Update()
    {
        if (targetToFollow == null) return;

        float z = Mathf.Clamp(targetToFollow.position.z, minZ, maxZ);
        transform.position = new Vector3(x, y, z);
    }
}
