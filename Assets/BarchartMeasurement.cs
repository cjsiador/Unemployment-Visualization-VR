using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction;
using Oculus.Interaction.Input;

public class BarchartMeasurement : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public int barchartValue;
    public float barchartStepValue = 0.003456402f; // Value for each Unity Measuremnt
    public GameObject targetObject;
    public GameObject sourceObject;
    public TMP_Text[] heightDigitText;
    public string valueString;

    public GrabInteractable grabInteractable; // TODO: Impliment a grabable.
    private Vector3 initialMeasurementPos;
    private Vector3 initialMeasurementRot;

    private float clampedZPos;

    void Start()
    {
        initialMeasurementPos = sourceObject.transform.localPosition;
        initialMeasurementRot = sourceObject.transform.localEulerAngles;
    }

    void Update()
    {
        ChangeHeightValue();
    }

    void ChangeHeightValue()
    {
        float zPos = sourceObject.transform.localPosition.z;

        clampedZPos = Mathf.Clamp(zPos, minHeight, maxHeight);

        // Lock rotations
        sourceObject.transform.localRotation = Quaternion.Euler(initialMeasurementRot);
        targetObject.transform.localRotation = Quaternion.Euler(initialMeasurementRot);

        // Clamp z-axis localPos
        sourceObject.transform.localPosition = new Vector3(initialMeasurementPos.x, initialMeasurementPos.y, clampedZPos);
        targetObject.transform.localPosition = new Vector3(initialMeasurementPos.x, initialMeasurementPos.y, clampedZPos);

        // Write value string
        barchartValue = Mathf.RoundToInt((sourceObject.transform.localPosition.z/barchartStepValue) * 100000);
        valueString = barchartValue.ToString();

        for(int i = heightDigitText.Length - 1; i >= 0; i--)
        {
            if(i >= valueString.Length)
            {
                heightDigitText[i].text = "";
            }
            else
            {
                heightDigitText[i].text = valueString[i].ToString();
            }
        } 
    }
}
