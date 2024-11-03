using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientHexTile : MonoBehaviour
{
    public GameObject hexTileObj;
    public float percentage;

    float timer = 0;
    public float timerDuration = 15f;

    // Start is called before the first frame update
    void Update()
    {
        timer += Time.deltaTime;

        float normalizedTime = Mathf.Clamp01(timer/timerDuration);

        var gradient = new Gradient();

        // Blend color from white 0% to blue 100%
        var colors = new GradientColorKey[2];

        Color32 colorYellow = new Color32(247,253,173,255);
        Color32 colorBlue = new Color32(3,81,116,255);

        colors[0] = new GradientColorKey(colorYellow, 0.0f);
        colors[1] = new GradientColorKey(colorBlue, 1.0f);

        // Blend alpha from opaque at 0% to transparent at 100%
        var alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(1.0f, 1.0f);

        gradient.SetKeys(colors, alphas);

        Color gradientColor = gradient.Evaluate((percentage * normalizedTime));

        var hexTileRenderer = hexTileObj.GetComponent<Renderer>().material;

        hexTileRenderer.color = gradientColor;
    }
}
