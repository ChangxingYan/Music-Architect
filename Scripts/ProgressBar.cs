using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour


{
    public int maximum;
    public int current;
    public Image fill;

    public Instantiator instantiator;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        GetCurrentFill();

    }


    void GetCurrentFill()
    {
        current = instantiator.Bar.Length;
        float fillAmount = (float)current / (float)maximum;
        fill.fillAmount = fillAmount;

    }
}
