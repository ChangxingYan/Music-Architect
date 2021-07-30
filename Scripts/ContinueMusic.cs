using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueMusic : MonoBehaviour
{





    private void OnEnable()
    {
        TryAgain.onCarriedOut += Reactivate;
    }

    private void OnDisable()
    {
        TryAgain.onCarriedOut -= Reactivate;
    }
    // Start is called before the first frame update
    void Reactivate()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private static ContinueMusic  instance = null;
    public static ContinueMusic Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {


        if (instance != null && instance != this)
        {

            this.gameObject.SetActive(false);
            return;
        }
        else
        {

            instance = this;
            DontDestroyOnLoad(this.gameObject);
            this.gameObject.SetActive(true);


        }


    }

   

}

