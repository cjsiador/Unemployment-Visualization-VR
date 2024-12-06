using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarchartHexTile : MonoBehaviour
{
    public float timerDuration = 1.0f;
    private float _totalAmount;
    public float TotalAmount
    {
        get => _totalAmount;
        set
        {
            if (Mathf.Approximately(_totalAmount, value)) return;

            OnValueChanged();
            _totalAmount = value;
            barchartCoroutine = StartCoroutine(BarchartUpdate());
        }
    }

    private float previousAmount = 0;
    private float timer = 0;
    private Coroutine barchartCoroutine;
    private GameObject barchartObj;

    void Awake()
    {
        barchartObj = transform.parent.gameObject;
    }

    private void OnValueChanged()
    {
        if (barchartCoroutine != null)
        {
            StopCoroutine(barchartCoroutine);
        }

        timer = 0;
        previousAmount = _totalAmount; // Store current percentage for lerping
    }

    IEnumerator BarchartUpdate()
    {
        while (timer < timerDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(timer / timerDuration);
            float currentLerpValue = Mathf.Lerp(previousAmount, _totalAmount, normalizedTime);
            
            barchartObj.transform.localScale = new Vector3(barchartObj.transform.localScale.x, barchartObj.transform.localScale.y, currentLerpValue/1000000);

            yield return null;
        }

        barchartCoroutine = null; // Mark coroutine as finished
    }
}
