using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset;
    public float smooth;
    public Transform target;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(desiredPosition, transform.position, smooth);
        this.transform.position = smoothPosition;

        cam.orthographicSize = Mathf.Abs(desiredPosition.x - smoothPosition.x)*10+3;

    }
}
