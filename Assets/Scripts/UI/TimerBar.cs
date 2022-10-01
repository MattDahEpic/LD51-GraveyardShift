using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;
    public GameManager manager;

    void Update()
    {
        slider.value = manager.TimerPercentage;
        text.text = manager.Time.ToString("N1");
    }
}
