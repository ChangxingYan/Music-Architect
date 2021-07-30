using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Instantiator))]
public class Judgement : MonoBehaviour
{
    public AudioClip[] m_audioClip = new AudioClip[7];
    public AudioSource m_audioSource;
    [SerializeField]
    private Instantiator instantiator;
    bool MyFunctionCalled = false;
    string substring;



    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
     //   instantiator = GameObject.Find("Instantiator").GetComponent<Instantiator>();

        m_audioSource = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        MyFunctionCalled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
       
        instantiator = GameObject.Find("Instantiator").GetComponent<Instantiator>();

        m_audioSource = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();

    }
    void OnDisable()
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Update is called once per frame





   public void PlayMusic()
    {
        if (instantiator.Bar.Length == 7)
        {
            substring = instantiator.Bar.Substring(0, 1);
        }

       

            for (int counter = 0 ; counter < 7 ; counter++)
        {
            if(substring == $"{counter}"  && MyFunctionCalled == false)
            {
                MyFunctionCalled = true;
                m_audioSource.clip = m_audioClip[counter];
                m_audioSource.Play();
            }
        }
       
    }
}