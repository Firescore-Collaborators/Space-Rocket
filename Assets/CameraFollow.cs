using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetObject;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float smoothFactor = 0.5f;
    [SerializeField] bool lookAtTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if(lookAtTarget)
        {
            transform.LookAt(targetObject);
        }
    }
}
