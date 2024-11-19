using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class UnemploymentDataFilter : MonoBehaviour
{
    public string filePath = "Cleaned_Averaged_Unemployment_Per_State_and_Year.json";
    public UnemploymentDataList dataList;
    public List<UnemploymentData> filteredByYear;

    public int yearFilter = 1976;

    void Start()
    {
        string jsonPath = Path.Combine(Application.streamingAssetsPath, filePath);
        if (File.Exists(jsonPath))
        {
            string jsonData = File.ReadAllText(jsonPath);
            
            dataList = JsonUtility.FromJson<UnemploymentDataList>(jsonData);

            FilterByYear(yearFilter);
        }
        else
        {
            Debug.LogError($"File not found at path: {jsonPath}");
        }
    }

    public void FilterByYear(int year)
    {
        if (dataList != null && dataList.UnemploymentData != null)
        {
            filteredByYear = dataList.UnemploymentData.Where(entry => entry.Year == year).ToList();

            Debug.Log($"Filtered Data for {year}: {filteredByYear.Count} entries.");
            
            // Example: Print the first state's data if available
            if (filteredByYear.Count > 0)
                Debug.Log($"First entry: State - {filteredByYear[0].State}, Year - {filteredByYear[0].Year}");
        }
        else
        {
            Debug.LogWarning("Data not loaded or invalid.");
        }
    }
}

[System.Serializable]
    public class UnemploymentData
    {
        public int Year;
        public string State;
        public float FIPS_Code;
        public int Total_Civilian_NonInstitutional_Population_in_State;
        public int Total_Civilian_Labor_Force_in_State;
        public float Percent_of_State_Population;
        public int Total_Employment_in_State;
        public float Percent_of_Labor_Force_Employed_in_State;
        public float Total_Unemployment_in_State;
        public float Percent_of_Labor_Force_Unemployed_in_State;
    }

[System.Serializable]
public class UnemploymentDataList
{
    public List<UnemploymentData> UnemploymentData;
}
