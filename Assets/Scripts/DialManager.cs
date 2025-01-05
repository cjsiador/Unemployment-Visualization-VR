using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialManager : MonoBehaviour
{
    public Transform targetObject;
    public Transform sourceObject;
    public float minYAxis = -180f; // Minimum allowed Y rotation in degrees
    public float maxYAxis = 180f; // Maximum allowed Y rotation in degrees

    private float continuousYRotation; // Tracks the continuous Y rotation of the target

    private Quaternion _dialLocalRotation;

    private float currentTargetY; // Tracks the continuous y-axis value

    private Vector3 initialPosition;
    private Vector3 initialRotation;

    void Start()
    {
        // Initialize the starting local rotation of the Dial
        // _dialLocalRotation = Dial.transform.localRotation;
        initialPosition = sourceObject.localPosition;
        initialRotation = sourceObject.localEulerAngles;
    }

    void Update()
    {
        float sourceZ = sourceObject.localEulerAngles.z;
        float deltaY = Mathf.DeltaAngle(targetObject.localEulerAngles.y, sourceZ);

        // Update the continuous rotation
        continuousYRotation += deltaY;
        continuousYRotation = Mathf.Clamp(continuousYRotation, minYAxis, maxYAxis);

        // Apply the continuous Y rotation to the target
        Vector3 targetEulerAngles = targetObject.localEulerAngles;
        targetEulerAngles.y = continuousYRotation;
        
        float clampedY = Mathf.Clamp(targetEulerAngles.y, minYAxis, maxYAxis);

        targetEulerAngles.y = clampedY;

        Vector3 sourceMinEulerAngles = sourceObject.localEulerAngles;
        Vector3 sourceMaxEulerAngles = sourceObject.localEulerAngles;
        Vector3 sourceEulerAngles = initialRotation;

        sourceMinEulerAngles.z = minYAxis;
        sourceMaxEulerAngles.z = maxYAxis;
        

        sourceEulerAngles.z = continuousYRotation;

        targetObject.localRotation = Quaternion.Euler(targetEulerAngles);
    
        sourceObject.localRotation = Quaternion.Euler(sourceEulerAngles);
        sourceObject.localPosition = initialPosition;
    }
}