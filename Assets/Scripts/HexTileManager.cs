using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileManager : MonoBehaviour
{
    public GameObject[] hexTileStates;
    public float[] hexTilePercentage;
    public UnemploymentDataFilter unemploymentDataFilterScript;

    public int filteredByYear;

    private int minYear = 1976;
    private int maxYear = 2022;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateGradientHex();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            filteredByYear -= 1;
            filteredByYear = Mathf.Clamp(filteredByYear, minYear, maxYear);
            
            unemploymentDataFilterScript.yearFilter = filteredByYear;
            unemploymentDataFilterScript.FilterByYear(filteredByYear);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            filteredByYear += 1;
            filteredByYear = Mathf.Clamp(filteredByYear, minYear, maxYear);

            unemploymentDataFilterScript.yearFilter = filteredByYear;
            unemploymentDataFilterScript.FilterByYear(filteredByYear);
        }
    }

    public void UpdateGradientHex()
    {
        // hexTilePercentage = unemploymentDataFilterScript.GetComponent<UnemploymentDataFilter>().filteredByYear;

        for(int t = 0; t < 51; t++)
        {   
            hexTilePercentage[t] = unemploymentDataFilterScript.filteredByYear[t].Percent_of_State_Population;
        }

        int i = 0;
        foreach(var hexTileState in hexTileStates)
        {
            hexTileState.GetComponent<GradientHexTile>().Percentage = unemploymentDataFilterScript.filteredByYear[i].Percent_of_State_Population;
            i++; 
        }
    }
}
