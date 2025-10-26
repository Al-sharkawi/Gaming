using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothSpeed = 0.125f;

    public bool useBounds = false;
    public float minX, maxX, minY, maxY;

    void FixedUpdate()
    {
        if (target == null) return; 

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        if (useBounds)
        {
            float clampX = Mathf.Clamp(smoothedPosition.x, minX, maxX);
            float clampY = Mathf.Clamp(smoothedPosition.y, minY, maxY);
            transform.position = new Vector3(clampX, clampY, offset.z);
        }
        else
        {
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, offset.z); // ✅ Fixed "mew" typo
        }
    }
}
