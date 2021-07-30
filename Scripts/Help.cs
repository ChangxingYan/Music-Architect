using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject helpText;

    public void ShowHelpText()
    {
        if(helpText.activeSelf == true)
        {
            helpText.SetActive(false);
        }
        else
        {
            helpText.SetActive(true);
        }

    }
}
