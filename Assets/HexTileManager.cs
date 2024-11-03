using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileManager : MonoBehaviour
{
    public GameObject[] hexTileStates;

    public float[] hexTilePercentage;

    void Start()
    {
        UpdateGradientHex();
    }

    public void UpdateGradientHex()
    {
        int i = 0;

        foreach(var hexTileState in hexTileStates)
        {
            hexTileState.GetComponent<GradientHexTile>().percentage = hexTilePercentage[i];

            // gradientHexTileScript.percentage = hexTilePercentage[i];

            i++; 
        }
    }
}
