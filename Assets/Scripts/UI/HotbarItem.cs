using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotbarItem : MonoBehaviour
{
    public Sprite sprite;
    public new string name;

    public float riseAmount;
    public float riseTime;
    private Vector3 startPos;
    private Vector3 upPos;

    private bool isHovering = false;

    void Start()
    {
        startPos = transform.position;
        upPos = startPos + new Vector3(0, riseAmount, 0);
    }

    void Update()
    {
        if (isHovering && Input.GetMouseButtonDown(0))
        {
            MouseHandler.instance.holding = name;
            MouseHandler.instance.holdingSprite = sprite;
        }
    }

    void OnDisable()
    {
        isHovering = false;
    }

    public void OnPointerEnter()
    {
        isHovering = true;
        StartCoroutine(DoSelfLerp(startPos, upPos, riseTime));
    }

    public void OnPointerExit()
    {
        isHovering = false;
        StartCoroutine(DoSelfLerp(upPos, startPos, riseTime));
    }
    private IEnumerator DoSelfLerp(Vector3 start, Vector3 end, float time)
    {
        float elapsed = 0;
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, elapsed / time);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }
}
