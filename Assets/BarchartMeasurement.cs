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
    public GameObject measurementObj;
    public TMP_Text[] heightDigitText;
    public string valueString;

    public GrabInteractable grabInteractable; // TODO: Impliment a grabable.

    void Update()
    {
        ChangeHeightValue();
    }

    void ChangeHeightValue()
    {
        barchartValue = Mathf.RoundToInt((measurementObj.transform.localPosition.z/barchartStepValue) * 100000);
        valueString = barchartValue.ToString();

        Debug.Log(valueString.Length);

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
