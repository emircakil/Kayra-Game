using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceSound : MonoBehaviour
{
    public float ambianceTimer;
    AudioSource audioSource;
    public AudioClip ambiance1;
    public AudioClip ambiance2;
    bool isAmbiance1 = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(playSound());
    }


    IEnumerator playSound() { 
        
        while (true)
        {
            yield return new WaitForSecondsRealtime(audioSource.clip.length + ambianceTimer);

            if (isAmbiance1)
            {
                audioSource.clip = ambiance1;
                audioSource.volume = 1f;
                isAmbiance1 = false;
            }
            else {
                audioSource.clip = ambiance2;
                audioSource.volume = 0.6f;
                isAmbiance1 = true;
            }

            audioSource.Play();
            


        }
    }
}
