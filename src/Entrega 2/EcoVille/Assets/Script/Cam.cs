using UnityEngine;

public class Cam : MonoBehaviour
{
    public Camera cameraComponent;
    public float horizontalRotationValule;
    public float verticalRotationValule;
    public float distanceOfTarget;
    public float heightOfCamera;
    public Transform target;
    public Transform child;

   
    void Update()
    {
        horizontalRotationValule += Input.GetAxis("Horizontal");
        verticalRotationValule += Input.GetAxis("Vertical");
        transform.rotation = Quaternion.Euler(0, horizontalRotationValule, 0);
        transform.position = target.position;
        child.transform.localPosition = new Vector3(0, heightOfCamera, -distanceOfTarget);
    }
}
