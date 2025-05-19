using Unity.Cinemachine;
using UnityEngine;

public class ControlZoom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<CinemachineCameraOffset>().Offset.z += 1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<CinemachineCameraOffset>().Offset.z -= 1f;
        }
    }
}
