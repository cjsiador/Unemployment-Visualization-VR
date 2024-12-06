using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GradientHexTile : MonoBehaviour
{
    public float timerDuration = 2.5f;

    private float _percentage;
    public float Percentage
    {
        get => _percentage;
        set
        {
            if (Mathf.Approximately(_percentage, value)) return;

            OnPercentageChanged();
            _percentage = value;
        }
    }

    private float previousPercentage = 0;
    private float timer = 0;
    private Gradient gradient;
    private Coroutine gradientCoroutine;

    void Awake()
    {
        InitializeGradient();
    }

    void InitializeGradient()
    {
        gradient = new Gradient();

        var colors = new GradientColorKey[2];
        colors[0] = new GradientColorKey(new Color32(247, 253, 173, 255), 0.5f);
        colors[1] = new GradientColorKey(new Color32(3, 81, 116, 255), 0.75f);

        var alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(1.0f, 1.0f);

        gradient.SetKeys(colors, alphas);
    }

    private void OnPercentageChanged()
    {
        if (gradientCoroutine != null)
        {
            StopCoroutine(gradientCoroutine);
        }

        timer = 0;
        previousPercentage = _percentage; // Store current percentage for lerping

        gradientCoroutine = StartCoroutine(GradientUpdate());
    }

    IEnumerator GradientUpdate()
    {
        while (timer < timerDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(timer / timerDuration);
            float currentLerpValue = Mathf.Lerp(previousPercentage, _percentage, normalizedTime);

            Color gradientColor = gradient.Evaluate(currentLerpValue / 100);
            GetComponent<Renderer>().material.color = gradientColor;

            yield return null;
        }

        gradientCoroutine = null; // Mark coroutine as finished
    }
}