using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YearText : MonoBehaviour
{
    public UnemploymentDataFilter unemploymentDataFilterScript;
    public TMP_Text yearText;

    private int _year;
    public int Year
    {
        get => _year;
        set 
        {
            if (_year == value)
                return;

            _year = value;
             ChangeYearText();
        }
    }

    void Update()
    {
        Year = unemploymentDataFilterScript.yearFilter;
    }

    public void ChangeYearText()
    {
        yearText.text = _year.ToString();
    }
}
