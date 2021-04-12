using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset;
    public float smooth;
    public Transform target;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(desiredPosition, transform.position, smooth);
        this.transform.position = smoothPosition;
    }
}
