using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public AudioSource musicPlayer;

    public delegate void BackGame();
    public static event BackGame onCarriedOut;

    private void Start()
    {
        musicPlayer = FindObjectOfType<AudioSource>();
    }
    // Start is called before the first frame update
    public void BackToGame()
    {
        SceneManager.LoadScene("startMenu");
        musicPlayer.gameObject.SetActive(true);
        musicPlayer.clip = null;
        if(onCarriedOut != null)
        {
            onCarriedOut();
        }
    }
}
