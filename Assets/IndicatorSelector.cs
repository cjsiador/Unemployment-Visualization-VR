using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorSelector : MonoBehaviour
{
    public float minDegree;
    public float maxDegree;
    public int numberOfObjects;
    public float angleStep;

    public GameObject rotationDial;
    public Vector3 currentAngle;

    public float minYAxis;
    public float maxYAxis;
    public float rangeDegree;

    public float currentIndicator;

    public float indicatorStep;

    public Vector3 currentRotation;
    public float indicatorStepPercent;

    public float minYear;
    public float currentYear;

    void Start()
    {
        SelectIndicatorYear();
    }

    void Update()
    {
        currentRotation = rotationDial.transform.localEulerAngles;

        currentAngle.x = NormalizeAngle(currentRotation.x);
        currentAngle.y = NormalizeAngle(currentRotation.y);
        currentAngle.z = NormalizeAngle(currentRotation.z);

        currentAngle.z = Mathf.Clamp(currentAngle.z, 0, rangeDegree);

        indicatorStep = currentAngle.z / angleStep;
        indicatorStepPercent = (currentAngle.z % angleStep) / angleStep;
        currentIndicator = Mathf.Round(indicatorStep);
        currentYear = minYear + currentIndicator;
    }

    float NormalizeAngle(float angle)
    {
        angle %= 360f; // Ensure the angle is within -360 to 360

        float tempMinDegree = angle;
        float tempMaxDegree = angle;

        float normalizedAngle = 0;

        if(minDegree < 0)
        {
            tempMinDegree = 360 - Mathf.Abs(minDegree);
        }

        if(maxDegree < 0)
        {
            tempMaxDegree = 360 - Mathf.Abs(maxDegree);
        }

        if ((angle >= tempMinDegree - 30) && (angle < 360))
        {
            angle -= tempMinDegree;
            return angle;
        }

        if ((angle >= 0) && (angle <= maxDegree + 30))
        {
            angle += (360 - Mathf.Abs(tempMinDegree));
            return angle;
        }

        return angle;
    }

    void SelectIndicatorYear()
    {
        // Calculate the step size for even distribution
        angleStep = (maxDegree - minDegree) / (numberOfObjects - 1);
        rangeDegree = maxYAxis - minYAxis;
    }
}
