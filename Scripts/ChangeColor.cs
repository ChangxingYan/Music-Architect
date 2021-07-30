using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color startColor;

    SpriteRenderer renderler;
    private void OnMouseEnter()
    {

        renderler = GetComponent<SpriteRenderer>();
        renderler.color = new Color(1, 0.694f, 0.211f);
    }
    private void OnMouseExit()
    {

        renderler = GetComponent<SpriteRenderer>();
        renderler.color = startColor;

    }

}
