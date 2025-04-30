using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
public class TouchControl : MonoBehaviour
{
    private Vector3 touchOffset;
    private float initialDistance;

    // Triggered when clicked
    public void OnPointerDown(PointerEventData eventData) {
        // Calculate the offset between the touch points and the center of the model
        touchOffset = transform.position - GetTouchWorldPos(eventData);
    }

    // Triggered when dragging (moving)
    public void OnDrag(PointerEventData eventData) {
        // Single-point touch: Move
        if (Input.touchCount == 1) { 
            transform.position = GetTouchWorldPos(eventData) + touchOffset;
        }
    }

    // Obtain the world coordinates of the touch point (adapted to AR scenarios)
    private Vector3 GetTouchWorldPos(PointerEventData data) {
        Ray ray = Camera.main.ScreenPointToRay(data.position);
        Plane plane = new Plane(Vector3.forward, transform.position); // 假设分子在XY平面
        plane.Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }

    void Update() {
    // Two-finger touch: zoom and rotate
    if (Input.touchCount == 2) { 
        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);

        // Calculate the change in the distance between two fingers (scaling)
        if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) {
            float currentDistance = Vector2.Distance(touch1.position, touch2.position);
            float previousDistance = Vector2.Distance(touch1.position - touch1.deltaPosition, 
                                                     touch2.position - touch2.deltaPosition);
            float scaleFactor = currentDistance / previousDistance;
            transform.localScale *= scaleFactor;

            // Limit the zoom range
            transform.localScale = Vector3.Max(transform.localScale, new Vector3(0.5f, 0.5f, 0.5f));
            transform.localScale = Vector3.Min(transform.localScale, new Vector3(3.0f, 3.0f, 3.0f));
        }

        // Two-finger rotation
        Vector2 prevDir = touch1.position - touch1.deltaPosition - (touch2.position - touch2.deltaPosition);
        Vector2 currentDir = touch1.position - touch2.position;
        float angle = Vector2.SignedAngle(prevDir, currentDir);
        transform.Rotate(Vector3.up, angle, Space.World);
    }
}
}
