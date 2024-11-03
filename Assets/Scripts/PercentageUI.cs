using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PercentageUI : MonoBehaviour
{
    public float stateAreaPopPercent;
    public float laborForceEmployedinStateAreaPercent;

    public Slider statePopUI;
    public Slider laborPopUI;

    public TMP_Text statePopTextUI;
    public TMP_Text laborPopTextUI; 

    float timer = 0;
    public float timerDuration = 7f;

    void Update()
    {
        timer += Time.deltaTime;

        float normalizedTime = Mathf.Clamp01(timer/timerDuration);

        statePopUI.value = (stateAreaPopPercent * normalizedTime) / 100;
        laborPopUI.value = (laborForceEmployedinStateAreaPercent * normalizedTime) / 100;

        statePopTextUI.text = ((stateAreaPopPercent * normalizedTime).ToString("f1") + " %");
        laborPopTextUI.text = ((laborForceEmployedinStateAreaPercent * normalizedTime).ToString("f1") + " %");
    }
}
