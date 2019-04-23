using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_HealthTextBox : MonoBehaviour {

    public GameObject child;                // Child of orb

    public CanvasGroup cg;                  // Canvas group

    public Text CollectText;                // Text for what was collected

    public Canvas Canvas;                   // Reference to a specific canvas

    public float ReadText;                  // Amount of time before dash can be used again

    // If player collides with collectible orb, play the collect animation
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(child);
            if (CollectText)
                CollectText.text = "You found a Health PowerUp! Collect these to heal!";
            DialogueBox();
        }
    }

    // Raise dialogue box alpha to a visible level
    public void DialogueBox() {
        if (cg.alpha == 0.0f) {
            cg.alpha = 1.0f;
        }
        StartCoroutine(BoxTimer());
    }

    // Time to read text
    IEnumerator BoxTimer() {
        yield return new WaitForSeconds(ReadText);
        if (cg.alpha == 1.0f) {
            cg.alpha = 0.0f;
        }
        StopCoroutine(BoxTimer());
        Destroy(this.gameObject);
    }
}