using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoulsBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;
    public GameManager manager;

    void Update()
    {
        slider.value = manager.SoulsPercentage;
        text.text = $"{manager.SoulCount}/{manager.SoulGoal}";
    }
}
