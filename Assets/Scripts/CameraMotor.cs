using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt; //Our Character // object we're looking at
    public Vector3 offset = new Vector3(0, 5.0f, -10.0f);

    private void LateUpdate()
    {
        Vector3 desiredPosition = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position,desiredPosition,Time.deltaTime+0.1f);
    }
 
}
