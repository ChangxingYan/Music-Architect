using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesTitlePos : MonoBehaviour
{
RectTransform rect;
    public RectTransform canvas;
    // Start is called before the first frame update
    void Start()
    {

        rect = GetComponent<RectTransform>();
            rect.anchoredPosition= -new Vector2(Screen.width / canvas.localScale.x, Screen.height / canvas.localScale.y) / 2;
    }

    // Update is called once per frame

}
