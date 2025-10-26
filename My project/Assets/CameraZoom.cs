using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    public float targetZoom = 3f;
    public float scrollData;
    public float zoomSpeed = 3f;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("CameraZoom script must be attached to a Camera!");
            return;
        }

        targetZoom = cam.orthographicSize; 
    }

    void Update()
    {
        scrollData = Input.GetAxis("Mouse ScrollWheel"); 
        targetZoom -= scrollData; 
        targetZoom = Mathf.Clamp(targetZoom, 3f, 6f); 
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
    }
}
