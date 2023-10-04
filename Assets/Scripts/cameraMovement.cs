using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    Transform target;

    public float smoothSpeed;

    public Vector3 offset;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
       Vector3 desiredPosition = target.position + offset;
       Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }

}
