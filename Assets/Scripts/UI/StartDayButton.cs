using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDayButton : MonoBehaviour
{
    public GameObject button;

    void Update()
    {
        button.SetActive(GameManager.instance.ShowStartDayButton && !GameManager.TimerEnabled);
    }

    public void DoPress()
    {
        GameManager.TimerEnabled = true;
    }
}
