using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RunningSoundEffect : MonoBehaviour {

    public GameObject CollidedObject = null;    // Ensures the collision codes work

    AudioSource Audio;                          // Makes audio work
    public AudioClip RunSFX;                    // Play specific audio clip

    void OnCollisionEnter2D(Collision2D collision) {
        // When player enters the enemy's vision, the enemy will run towards the player
        if (collision.gameObject.tag == "Player") {
            GM_SoundManager.instance.PlaySound(RunSFX);
        }
    }
}
