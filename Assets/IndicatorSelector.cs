using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorSelector : MonoBehaviour
{
    public float minDegree;
    public float maxDegree;

    public Vector3 minRotation;
    public Vector3 maxRotation;

    public int numberOfObjects;
    public float angleStep;

    public GameObject rotationDial;
    public Vector3 rotationAngle;

    void Start()
    {
        SelectIndicatorYear();
    }

    void Update()
    {
        Vector3 currentRotation = rotationDial.transform.localEulerAngles;

        // Clamp each axis
        // currentRotation.x = ClampAngle(currentRotation.x, minRotation);

        rotationAngle = rotationDial.transform.localEulerAngles;
        // rotationDial.transform.localEulerAngles 
    }

    // private float ClampAngle(float angle, float min, float max)
    // {
    //     // Normalize the angle to the range 
    //     angle = angle % 360;
    // }

    void SelectIndicatorYear()
    {
        // Calculate the step size for even distribution
        angleStep = (maxDegree - minDegree) / (numberOfObjects - 1);
    }
}
