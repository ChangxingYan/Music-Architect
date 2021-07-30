using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowClick : MonoBehaviour
{
    public Color startColor;
    public bool mouseDown;
    SpriteRenderer renderler;
    private void OnMouseDown()
    {
        mouseDown = true;
        renderler = GetComponent<SpriteRenderer>();
        renderler.color = new Color(0.592f, 0.792f, 0.953f);

    }
    private void OnMouseUp()
    {
        mouseDown = false;
        renderler = GetComponent<SpriteRenderer>();
        renderler.color = startColor;

    }
}

