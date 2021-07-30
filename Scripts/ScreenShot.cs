using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup canvas;

    public Text help;


    public void TakeScreenshot()
    {
        string folderPath = Directory.GetCurrentDirectory() + "/Screenshots/";

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var screenshotName =
                                "Screenshot_" +
                                System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") +
                                ".png";
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
        Debug.Log(folderPath + screenshotName);
    }

    public void ShowHelp()
    {
        if(help != null)
        {

            help.gameObject.SetActive(true);
            Destroy(help.gameObject, 3);
        }

        
    }

    public void TurnOff()
    {
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        canvas.alpha = 0;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.5f);

        //After we have waited 5 seconds print the time again.
        canvas.alpha = 1;
    }
}
