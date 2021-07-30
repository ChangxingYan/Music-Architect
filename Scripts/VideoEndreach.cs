using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

using UnityEngine.Networking;
public class VideoEndreach : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer Player;
    public bool isPlayerStarted = false;

    public Instantiator instantiator;


    public Button skipAnimation;
    public AsyncOperation async;
    public int number;
    public GameObject[] destroys;
    public string filepath;

    // Start is called before the first frame update

    void Awake()
    {

        //uses a preprocessor to check whether the file will be read synchronously (local) or async (web)
#if UNITY_WEBGL
        StartCoroutine("ReadFileAsync");
#else
            ReadExternalFile();
#endif
    }

    IEnumerator ReadFileAsync()
    {
        UnityWebRequest www = UnityWebRequest.Get(Application.dataPath + filepath);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            byte[] data = www.downloadHandler.data;


            //read results as text
        }
        ReadExternalFile();
    }


    void Start()
    {
        Player = gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();


    }

    // Update is called once per frame
    private void Update()
    {
        if (Player.isPlaying == true)
        {
            if (this != null && instantiator.generate.gameObject != null)
            {



                destroys = GameObject.FindGameObjectsWithTag("Destroys");


                foreach (GameObject destroy in destroys)
                {
                    Destroy(destroy);
                }
                for (int counter = 0; counter < 7; counter++)
                {
                    Destroy(instantiator.textPositions[counter]);
                }

                skipAnimation.gameObject.SetActive(true);
            }




        }
        if (isPlayerStarted == false && Player.isPlaying == true)
        {
            // When the player is started, set this information
            isPlayerStarted = true;

            if (instantiator.Bar.Length == 7)
            {
                string substring = instantiator.Bar.Substring(0, 1);
                number = Int32.Parse(substring);


                async = SceneManager.LoadSceneAsync(number + 2);
                async.allowSceneActivation = false;
            }

        }
        if (isPlayerStarted == true && Player.isPlaying == false)
        {
            // Wehen the player stopped playing, hide it
            // Player.gameObject.SetActive(false);

            async.allowSceneActivation = true;




        }





    }

    /* private IEnumerator LoadYourAsyncScene()
     {
         asyncOperation = SceneManager.LoadSceneAsync(number + 2);
         asyncOperation.allowSceneActivation = false;
         yield return null;
         Debug.Log("Load Async");
     }
    */
    public void StopAndLoad()
    {
        async.allowSceneActivation = true;
        Player.Stop();

    }


    void ReadExternalFile()
    {



        //  #if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        // StreamReader r = new StreamReader(Application.dataPath + filepath);
        // # endif
        if (System.IO.File.Exists(Application.streamingAssetsPath + "/generation.mp4"))
        {

            Player.url = Path.Combine(Application.streamingAssetsPath, "generation.mp4");
            Player.Prepare();
            Debug.Log("FileExists");
        }
        else
        {
            Debug.Log("FileDontExists");
        }



    }


   public void OnClick()
    {
        if (instantiator.Bar.Length == 7)
        {
            string substring = instantiator.Bar.Substring(0, 1);
            number = Int32.Parse(substring);


            async = SceneManager.LoadSceneAsync(number + 2);
            async.allowSceneActivation = false;
            async.allowSceneActivation = true;
        }
    }
}


