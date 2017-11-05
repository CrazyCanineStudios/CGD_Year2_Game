using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public Camera camera1;
    public float originalFov;
    public Vector3 originalOffset;
    public float fov;
    public float rotation;
    public float xPos;
    public float yPos;
    public float zPos;

    private void Awake()
    {
        originalFov = camera1.fieldOfView;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            camera1.GetComponent<CameraFollow>().offset = new Vector3(xPos, yPos, zPos);
            camera1.transform.localEulerAngles = new Vector3(rotation, 0, 0);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            camera1.GetComponent<CameraFollow>().offset = originalOffset;
            camera1.transform.localEulerAngles = new Vector3(12.82f, 0, 0);
        }
    }
}
