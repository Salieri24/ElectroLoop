using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset;
    public float smooth;
    public Transform target;
    public Rigidbody2D targetRigid;

    public float maxCamSize;

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

        cam.orthographicSize = Mathf.Abs(targetRigid.velocity.x)*0.2f+3;
        if (cam.orthographicSize >= maxCamSize)
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,maxCamSize, smooth);
    }
}
