using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicNoteSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] m_audioClip = new AudioClip[7];
    public AudioSource m_audioSource;


    private void Start()
    {

        m_audioSource = GetComponent<AudioSource>();

    }

    public void PlayParticleAndAudio(int a)
    {
        if (a == 0)
        {
            m_audioSource.clip = m_audioClip[0];
            m_audioSource.Play();
            Debug.Log("do");

        }
        if (a == 1)
        {
            m_audioSource.clip = m_audioClip[1];
            m_audioSource.Play();
            Debug.Log("re");

        }
        if (a == 2)
        {
            m_audioSource.clip = m_audioClip[2];
            m_audioSource.Play();

        }
        if (a == 3)
        {
            m_audioSource.clip = m_audioClip[3];
            m_audioSource.Play();

        }
        if (a == 4)
        {
            m_audioSource.clip = m_audioClip[4];
            m_audioSource.Play();

        }
        if (a == 5)
        {
            m_audioSource.clip = m_audioClip[5];
            m_audioSource.Play();

        }
        if (a == 6)
        {
            m_audioSource.clip = m_audioClip[6];
            m_audioSource.Play();

        }
    }
}
