using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private const int GROWTH_STAGES = 3;

    private float _timer = GameManager.LOOP_TIME;

    public bool DirtEnabled = false;
    public bool DirtWet = false;
    public bool CropEnabled = false;
    private int CropStage { get { return 
                Mathf.FloorToInt(
                    Mathf.Lerp(0, GROWTH_STAGES - 1, 
                        (_timer+1) / GameManager.LOOP_TIME
                    )
                ); } }

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
            Crop.sprite = Crops[CropStage];

        _timer += Time.deltaTime;
        if (_timer >= GameManager.LOOP_TIME)
        {
            _timer = 0;

            if (GameManager.TimerEnabled)
            { //do harvesting mechanics

            }
        }
    }

    void OnMouseEnter()
    {
        Select.gameObject.SetActive(true);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    void OnMouseExit()
    {
        Select.gameObject.SetActive(false);
    }
}
