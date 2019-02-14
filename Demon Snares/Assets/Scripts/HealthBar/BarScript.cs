using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    private float fillAmount;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Image fill;

    [SerializeField]
    private Text valueText;

    public float MaxValue { get; set; }

    public float Value {
        set
        {
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value;
            fillAmount = MapHealth(value,0,MaxValue,0,1);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        // updates fill amount whenever it changes
        if (fillAmount != fill.fillAmount)
        {
            fill.fillAmount = Mathf.Lerp(fill.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
    }

    private float MapHealth(float value, float inMin, float inMax, float outMin, float outMax)
    {
        // maps the actual health value to a value that the fillamount can understand
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
