using UnityEngine;
using Vuforia;

public class FaceCamera : MonoBehaviour {
    void Update() {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}