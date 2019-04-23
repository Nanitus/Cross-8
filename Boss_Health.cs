using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Health : MonoBehaviour {

    private Animator Animation;                 // Enables animations

    private void Start() {
        // What object needs to be animated to look for
        Animation = gameObject.GetComponent<Animator>();
    }

    private void Update() {

        // If health is 5, play specific animation
        if (GameManager.instance.BossHealth == 5) {
            Animation.SetTrigger("Damaged");
        }

        // If health is 4, play specific animation
        if (GameManager.instance.BossHealth == 4) {
            Animation.SetTrigger("Damage2");
        }

        // If health is 3, play specific animation
        if (GameManager.instance.BossHealth == 3) {
            Animation.SetTrigger("Damage3");
        }

        // If health is 2, play specific animation
        if (GameManager.instance.BossHealth == 2) {
            Animation.SetTrigger("Damage4");
        }

        // If health is 1, play specific animation
        if (GameManager.instance.BossHealth == 1) {
            Animation.SetTrigger("Damage5");
        }

        // If health is 0, play specific animation
        if (GameManager.instance.BossHealth == 0) {
            Animation.SetTrigger("Damage6");
            SceneManager.LoadScene(6);
        }
    }
}