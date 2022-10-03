using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FailDisplay : MonoBehaviour
{
    public GameObject icon1;
    public GameObject icon2;
    public GameObject icon3;
    public GameObject overlay;

    public TMP_Text scoreDisplay;

    void Update()
    {
        icon1.SetActive(GameManager.instance.FailCount >= 1);
        icon2.SetActive(GameManager.instance.FailCount >= 2);
        icon3.SetActive(GameManager.instance.FailCount >= 3);
        overlay.SetActive(GameManager.instance.FailCount >= 3 && !GameManager.TimerEnabled);

        scoreDisplay.text = GameManager.instance.LoopCount.ToString();
    }
}
