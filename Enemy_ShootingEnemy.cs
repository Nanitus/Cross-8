using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ShootingEnemy : MonoBehaviour {

    public int ShootSpeed;                      // Speed of shot
    public int MissileDestroy;                  // Amount of time for missile to dissapear
    public int FireRate;                        // Amount of time for enemy to shoot again

    public Transform Launcher;                  // Object that shoots

    public GameObject EnemyBullet;              // Object shot
    public GameObject CollidedObject = null;    // Ensures the collision codes work

    private Animator Animation;                 // Enables animations

    bool isFired = false;                       // Bool to check if bullet is being shot

    AudioSource Audio;                          // Makes audio work
    public AudioClip MissileSFX;                // Play specific audio clip

    private void Start() {
        // What object needs to be animated to look for
        Animation = gameObject.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision) {
        // When player enters the enemy's vision, the enemy will shoot towards the player
        if (collision.gameObject.tag == "Player" && isFired != true) {
            GM_SoundManager.instance.PlaySound(MissileSFX);
            GameObject Missile = Instantiate(EnemyBullet, Launcher.position, Quaternion.identity);
            Rigidbody2D rb = Missile.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(-ShootSpeed, 0.0f));
            Destroy(Missile, MissileDestroy);
            isFired = true;
            StartCoroutine(BulletTimer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        // If enemy is hit by player's bullets
        if (collision.gameObject.tag == "Bullet") {
            Animation.SetTrigger("Damaged");
            Destroy(collision.gameObject);
        }
    }

    // Shooting timer
    IEnumerator BulletTimer() {
        yield return new WaitForSeconds(FireRate);
        isFired = false;
        StopAllCoroutines();
    }
}