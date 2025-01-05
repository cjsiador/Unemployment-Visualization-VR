using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileManager : MonoBehaviour
{
    public GameObject[] hexTileStates;
    public float[] hexTilePercentage; // Percent_of_State_Population
    public float[] hexTileBarchart;   // Total_Employment_in_State
    public UnemploymentDataFilter unemploymentDataFilterScript;

    public int _filteredByYear;
    public int filteredByYear
    {
        get { return _filteredByYear; }
        set { 
                if (_filteredByYear != value) 
                {
                    _filteredByYear = value;
                    unemploymentDataFilterScript.yearFilter = value;
                    unemploymentDataFilterScript.FilterByYear(value);
                    UpdateGradientHex();
                    UpdateBarchartHex();
                }
            }
    }

    private int minYear = 1976;
    private int maxYear = 2022;

    public IndicatorSelector indicatorSelectorScript;

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

            UpdateGradientHex();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            filteredByYear += 1;
            filteredByYear = Mathf.Clamp(filteredByYear, minYear, maxYear);

            unemploymentDataFilterScript.yearFilter = filteredByYear;
            unemploymentDataFilterScript.FilterByYear(filteredByYear);

            UpdateGradientHex();
        }

        filteredByYear = (int)indicatorSelectorScript.currentYear;
    }

    public void UpdateGradientHex()
    {
        // hexTilePercentage = unemploymentDataFilterScript.GetComponent<UnemploymentDataFilter>().filteredByYear;
        float percentTotal = 0f;


        for(int t = 0; t < 51; t++)
        {
            percentTotal = (unemploymentDataFilterScript.filteredByYear[t].Total_Unemployment_in_State / unemploymentDataFilterScript.filteredByYear[t].Total_Civilian_Labor_Force_in_State) * 100;
            percentTotal = (float)System.Math.Round(percentTotal, 1);

            hexTilePercentage[t] = percentTotal;
        }

        int i = 0;

        foreach(var hexTileState in hexTileStates)
        {
            hexTileState.GetComponent<GradientHexTile>().Percentage = hexTilePercentage[i];
            i++; 
        }
    }

    public void UpdateBarchartHex()
    {

        for(int t = 0; t < 51; t++)
        {
            hexTileBarchart[t] = unemploymentDataFilterScript.filteredByYear[t].Total_Employment_in_State;
        }

        int i = 0;

        foreach(var hexTileState in hexTileStates)
        {
            hexTileState.GetComponent<BarchartHexTile>().TotalAmount = unemploymentDataFilterScript.filteredByYear[i].Total_Employment_in_State;
            i++;
        }
    }
}
