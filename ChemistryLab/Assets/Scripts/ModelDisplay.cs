using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        gameObject.SetActive(false); // Initial hiding
    }

    void OnTrackingFound() { // Triggered when an image is recognized
        gameObject.SetActive(true);
    }

    void OnTrackingLost() { // It is triggered when the picture leaves the camera
        gameObject.SetActive(false);
    }
}
