using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = new Vector3 (0,0,-10);
    public Vector3 velocity;
    public float smoothTime = 0.2f;

    void Start()
    {
        transform.position = player.transform.position + offset;
    }

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref velocity, smoothTime);
    }
}
