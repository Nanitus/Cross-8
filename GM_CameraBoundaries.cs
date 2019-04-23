using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_CameraBoundaries : MonoBehaviour {

    Transform target;               // Object for camera to follow

    public Transform camBoundMin;   // Lowest and leftest value camera can move
    public Transform camBoundMax;   // Highest and rightest value camera can move

    float xMin, xMax, yMin, yMax;   // Variables
    
    void Start() {

       // Find the player to follow
       GameObject go = GameObject.FindWithTag("Player");
        if (!go) {
            Debug.Log("Player not found.");
            return;
        }
        target = go.GetComponent<Transform>();

        // Uses GameObjects to set the min and max values for camera movement
        xMin = camBoundMin.position.x;
        yMin = camBoundMin.position.y;

        xMax = camBoundMax.position.x;
        yMax = camBoundMax.position.y;
    }
    
    void Update() {
        // Change camera position to follow player
        if (target) {
            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, xMin, xMax),
                Mathf.Clamp(target.position.y, yMin, yMax),
                transform.position.z);
        }
    }
}