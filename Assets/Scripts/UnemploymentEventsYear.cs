using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class UnemploymentEventsYear : MonoBehaviour
{
    public string filePath = "unemploymentevents.json";
    public UnemploymentDataFilter unemploymentDataFilterScript;
    public TMP_Text yearText;
    public TMP_Text eventText;
    public TMP_Text sourceText;

    public UnemploymentEventList unemploymentEventList;

    public List<UnemploymentEventData> filteredByYear;

    private int _year;
    public int Year
    {
        get => _year;
        set 
        {
            if (_year == value)
                return;

            _year = value;

            FilterByYear(_year);
            ChangeYearText();
        }
    }

    void Start()
    {
        string jsonPath = Path.Combine(Application.streamingAssetsPath, filePath);
        if (File.Exists(jsonPath))
        {
            string jsonData = File.ReadAllText(jsonPath);
            
            unemploymentEventList = JsonUtility.FromJson<UnemploymentEventList>(jsonData);

            Year = unemploymentDataFilterScript.yearFilter;

            FilterByYear(Year);
        }
        else
        {
            Debug.LogError($"File not found at path: {jsonPath}");
        }
    }

    public void FilterByYear(int year)
    {
        if (unemploymentEventList != null && unemploymentEventList.UnemploymentEventData != null)
        {
            filteredByYear = unemploymentEventList.UnemploymentEventData.Where(entry => entry.Year == year).ToList();

            Debug.Log($"Filtered Data for {year}: {filteredByYear.Count} entries.");
            
            // Example: Print the first state's data if available
            if (filteredByYear.Count < 0)
            {
                Debug.LogWarning("Data not loaded or invalid.");
            }
        }
    }

    void Update()
    {
        Year = unemploymentDataFilterScript.yearFilter;
    }

    public void ChangeYearText()
    {
        yearText.text = filteredByYear[0].Year.ToString();
        eventText.text = filteredByYear[0].Event.ToString();
        sourceText.text = filteredByYear[0].Source.ToString();
    }

}

[System.Serializable]
public class UnemploymentEventData
{
    public int Year;
    public float Rate;
    public string Event;
    public string Source; 
}

[System.Serializable]
public class UnemploymentEventList
{
    public List<UnemploymentEventData> UnemploymentEventData;
}