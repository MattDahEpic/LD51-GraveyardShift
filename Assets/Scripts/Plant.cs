using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private const int GROWTH_STAGES = 3;
    private const float GROWTH_TIME = 7f;

    private float _timer = 0;

    public bool DirtEnabled = false;
    public bool DirtWet = false;
    public bool CropEnabled = false;
    private int CropStage { get { return 
                Mathf.FloorToInt(
                    Mathf.Lerp(0, GROWTH_STAGES - 1, 
                        (_timer) / GROWTH_TIME
                    )
                ); } }
    public bool ReadyToHarvest => _timer >= GROWTH_TIME;

    public SpriteRenderer Select;
    public SpriteRenderer Dirt;
    public SpriteRenderer Crop;

    public Sprite[] Dirts;
    public Sprite[] Crops;

    void Start()
    {
        Select.gameObject.SetActive(false);
    }

    void Update()
    {
        Dirt.gameObject.SetActive(DirtEnabled);
        if (DirtEnabled)
            Dirt.color = DirtWet ? Color.gray : Color.white;
            //Dirt.sprite = Dirts[DirtWet ? 1 : 0];
        Crop.gameObject.SetActive(CropEnabled);
        if (CropEnabled)
        {
            Crop.sprite = Crops[CropStage];

            if (DirtWet && (GameManager.TimerEnabled || TutorialManager.instance.InTutorial))
                _timer += Time.deltaTime;

            if (_timer >= GROWTH_TIME)
            {
                if (GameManager.TimerEnabled)
                { //do harvesting mechanics

                }
            }
        }
    }

    void OnMouseEnter()
    {
        Select.gameObject.SetActive(true);
        Select.color = Color.white;
    }

    void OnMouseOver()
    {
        bool doAction = Input.GetMouseButtonUp(0);

        if (ReadyToHarvest)
        {
            Select.color = Color.green;
            if (doAction && string.IsNullOrEmpty(MouseHandler.instance.holding))
            {
                DoHarvest();
                Select.color = Color.white;
                return;
            }
        }
            

        switch (MouseHandler.instance.holding)
        {
            case "dirt":
                if (DirtEnabled || GameManager.instance.Coins < 50)
                {
                    Select.color = Color.red;
                } else
                {
                    Select.color = Color.green;
                    if (doAction)
                    {
                        DirtEnabled = true;
                        GameManager.instance.Coins -= 50;
                        Select.color = Color.white;
                    }
                }                    
                break;
            case "seeds":
                if (!DirtEnabled || CropEnabled || GameManager.instance.Coins < 50)
                {
                    Select.color = Color.red;
                } else
                {
                    Select.color = Color.green;
                    if (doAction)
                    {
                        CropEnabled = true;
                        GameManager.instance.Coins -= 50;
                        Select.color = Color.white;
                    }
                }
                break;
            case "water":
                if (!DirtEnabled || DirtWet)
                {
                    Select.color = Color.red;
                }
                else
                {
                    Select.color = Color.green;
                    if (doAction)
                    {
                        DirtWet = true;
                    }
                }
                break;
        }
    }

    void OnMouseExit()
    {
        Select.gameObject.SetActive(false);
    }

    private void DoHarvest()
    {
        _timer = 0;
        CropEnabled = false;
        DirtWet = false;
        GameManager.instance.SoulCount++;
        GameManager.instance.Coins += 75;
        //TODO soul animation
    }
}
