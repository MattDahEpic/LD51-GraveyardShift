using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsDisplay : MonoBehaviour
{
    public GameManager manager;
    public TMPro.TMP_Text text;

    void Update()
    {
        text.text = manager.Coins.ToString();
    }
}
