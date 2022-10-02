using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : Singleton<MouseHandler>
{
    public MouseHandler() : base(false, false) { }

    public SpriteRenderer holdingRenderer;

    public Sprite holdingSprite;
    public string holding;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition.WithZ(10));

        if (
            !string.IsNullOrEmpty(holding) && 
            (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonUp(0))
           )
        {
            holding = null;
            holdingSprite = null;
        }
        holdingRenderer.sprite = holdingSprite;
    }
}
