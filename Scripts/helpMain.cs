using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpMain : MonoBehaviour
{
    public Text help;
    bool functionCalled = false;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {if(functionCalled == false)
        {
            ShowHelp();
            functionCalled = true;
        }


    }

    void ShowHelp()
    {
        if (help != null)
        {
            help.gameObject.SetActive(true);
            Destroy(help.gameObject, 3);

        }

    }
}
