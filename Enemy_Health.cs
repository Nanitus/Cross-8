using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {

    public int Health;                          // Enemy's health

    AudioSource Audio;                          // Makes audio work
    public AudioClip HitSFX;                    // Play specific audio clip
    public AudioClip DeathSFX;                  // Play specific audio clip

    public GameObject CollidedObject = null;    // Ensures the collision codes work

    void OnCollisionEnter2D(Collision2D collision) {
        // If player's bullet collides with enemy, make enemy health go down one unit
        if (collision.gameObject.tag == "Bullet") {
            GM_SoundManager.instance.PlaySound(HitSFX);
            Destroy(collision.gameObject);
            Health -= 1;
        }

        // If enemy health reaches 0 then delete the enemy
        if (Health <= 0) {
            GM_SoundManager.instance.PlaySound(DeathSFX);
            Destroy(gameObject);
        }
    }
}