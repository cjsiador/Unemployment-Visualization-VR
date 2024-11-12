using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UnemploymentDataFilter : MonoBehaviour
{
    [System.Serializable]
    public class UnemploymentData
    {
        public int Year;
        public string State;
        public float FIPSCode;
        public int TotalCivilianNonInstitutionalPopulationInState;
        public int TotalCivilianLaborForceInState;
        public int TotalEmploymentInState;
        public int TotalUnemploymentInState;
        public float PercentOfPopulation;
        public float PercentOfLaborForceEmployed;
        public float PercentOfLaborForceUnemployed;
    }

    [System.Serializable]
    public class UnemploymentDataList
    {
        public List<UnemploymentData> data;
    }

    public string filePath = "Cleaned_Averaged_Unemployment_Per_State_and_Year.json";
    
    public List<UnemploymentDataList> dataList;

    void Start()
    {
        string jsonPath = Path.Combine(Application.streamingAssetsPath, filePath);
        if (File.Exists(jsonPath))
        {
            string jsonData = File.ReadAllText(jsonPath);
            Debug.Log(jsonData);
            
            dataList.data = JsonUtility.FromJson<UnemploymentDataList>(jsonData);
            
            foreach (var data in dataList)
            {
                Debug.Log($"Year: {data.Year}, State: {data.State}, Unemployment: {data.TotalUnemploymentInState}");
            }
        }
        else
        {
            Debug.LogError($"File not found at path: {jsonPath}");
        }
    }
}