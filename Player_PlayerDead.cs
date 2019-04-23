using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_PlayerDead : MonoBehaviour {

    private Animator Animation;     // Enables animations

    AudioSource Audio;              // Makes audio work
    public AudioClip DeathSFX;      // Play specific audio clip

    private void Start() {
        // What object needs to be animated to look for
        Animation = gameObject.GetComponent<Animator>();
    }

    private void Update() {
        // If player health is 0 then disable player movement, play death animation, reduce lives by 1 and load death scene
        if (GameManager.instance.Health == 0) {
            GM_SoundManager.instance.PlaySound(DeathSFX);
            Animation.SetBool("Dead", true);
            Animation.SetTrigger("Death");
            GameManager.instance.Lives -= 1;
            SceneManager.LoadScene(3);
        }

        // If player lives is 0 then load game over scene
        if (GameManager.instance.Lives == 0) {
            SceneManager.LoadScene(4);
        }
    }
}