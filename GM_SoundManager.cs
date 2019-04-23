using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_SoundManager : MonoBehaviour {

    static GM_SoundManager _instance = null;    // Allows reference to SoundManager

    public AudioSource sfxSource;               // SFX source
    public AudioSource musicSource;             // BGM source
    public AudioSource[] audioSources;          // Reference to volume

    // Allows the use of audio in game
    void Start() {
        if (instance)
            Destroy(gameObject);
        else {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // playSingleSound is the sound that plays
    public void PlaySound(AudioClip clip, float volume = 1.0f) {
        if (sfxSource) {
            sfxSource.clip = clip;
            sfxSource.volume = volume;
            sfxSource.Play();
        }
    }

    // Reference for SoundManager
    public static GM_SoundManager instance {
        get { return _instance; }
        set { _instance = value; }
    }
}