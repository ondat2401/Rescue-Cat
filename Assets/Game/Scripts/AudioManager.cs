using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip caught;
    public AudioClip button;

    //add more clip
    private void Awake()
    {
        PlayMusic();
    }
    private void Update()
    {
        if (SFXSource.volume > .5f)
            SFXSource.volume = .5f;
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlayMusic()
    {
        musicSource.Play();
    }
}
