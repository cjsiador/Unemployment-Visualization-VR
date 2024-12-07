using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasurementInteractive : MonoBehaviour
{
    public Transform targetObject;
    public Transform sourceObject;

    public float minZAxis = 0;
    public float maxZAxis = 10;

    public float currentTargetZ;
    private Vector3 initialPosition;
    private Vector3 initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = sourceObject.localPosition;
        initialRotation = sourceObject.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        float sourceZ = sourceObject.localPosition.z;

        float clampedZ = Mathf.Clamp(sourceZ, minZAxis, maxZAxis);

        targetObject.localPosition = new Vector3(initialPosition.x, initialPosition.y, clampedZ);
        targetObject.localRotation = Quaternion.Euler(initialRotation);

        sourceObject.localPosition = new Vector3(initialPosition.x, initialPosition.y, clampedZ);
        sourceObject.localRotation = Quaternion.Euler(initialRotation);
    }
}
