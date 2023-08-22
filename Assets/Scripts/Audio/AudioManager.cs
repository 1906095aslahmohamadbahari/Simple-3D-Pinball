using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceBGM;
    [SerializeField] GameObject audioSourceSFX;

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();   
    }

    private void PlayBGM()
    {
        audioSourceBGM.Play();
    }

    public void playSFX (Vector3 spawnPosition)
    {
        GameObject.Instantiate (audioSourceSFX, spawnPosition, Quaternion.identity);
    }
}
