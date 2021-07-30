using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PLayTheGame()
    {
        SceneManager.LoadScene("Play");
    }
    public void QuitTheGame()
    {

        Debug.Log("Quit");
        Application.Quit();
    }
}
