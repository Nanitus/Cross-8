using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Shooting : MonoBehaviour {

    public int ShootSpeedX;                     // Speed of shot in the X axis
    public int ShootSpeedY;                     // Speed of shot in the Y axis
    public float CannonDestroy;                 // Amount of time for missile to dissapear
    public float FireRate;                      // Amount of time for enemy to shoot again

    public Transform Launcher;                  // Object that shoots

    public GameObject EnemyBullet;              // Object shot
    public GameObject CollidedObject = null;    // Ensures the collision codes work

    private Animator Animation;                 // Enables animations

    bool isFired = false;                       // Bool to check if bullet is being shot

    AudioSource Audio;                          // Makes audio work
    public AudioClip CannonSFX;                 // Play specific au
    public AudioClip HitSFX;                    // Play specific audio clip
    public AudioClip DeathSFX;                  // Play specific audio clip

    private void Start() {
        // What object needs to be animated to look for
        Animation = gameObject.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // When player enters the enemy's vision, the enemy will shoot towards the player
        if (collision.gameObject.tag == "Player" && isFired != true) {
            GM_SoundManager.instance.PlaySound(CannonSFX);
            GameObject Cannon = Instantiate(EnemyBullet, Launcher.position, Quaternion.identity);
            GameObject Cannon2 = Instantiate(EnemyBullet, Launcher.position, Quaternion.identity);
            GameObject Cannon3 = Instantiate(EnemyBullet, Launcher.position, Quaternion.identity);
            Rigidbody2D rb = Cannon.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = Cannon2.GetComponent<Rigidbody2D>();
            Rigidbody2D rb3 = Cannon3.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(-ShootSpeedX * transform.localScale.x, 0.0f));
            rb2.AddForce(new Vector2(-ShootSpeedX * transform.localScale.x, -ShootSpeedY * transform.localScale.y));
            rb3.AddForce(new Vector2(-ShootSpeedX * transform.localScale.x, ShootSpeedY * transform.localScale.y));
            Destroy(Cannon, CannonDestroy);
            Destroy(Cannon2, CannonDestroy);
            Destroy(Cannon3, CannonDestroy);
            isFired = true;
            StartCoroutine(BulletTimer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // If enemy is hit by player's bullets
        if (collision.gameObject.tag == "Bullet"){
            Animation.SetTrigger("Damaged");
            GM_SoundManager.instance.PlaySound(HitSFX);
            Destroy(collision.gameObject);
            GameManager.instance.BossHealth -= 1;
        }

        if (GameManager.instance.BossHealth <= 0) {
            GM_SoundManager.instance.PlaySound(DeathSFX);
            Destroy(gameObject);
            SceneManager.LoadScene(5);
        }
    }

    // Shooting timer
    IEnumerator BulletTimer(){
        yield return new WaitForSeconds(FireRate);
        isFired = false;
        StopAllCoroutines();
    }
}