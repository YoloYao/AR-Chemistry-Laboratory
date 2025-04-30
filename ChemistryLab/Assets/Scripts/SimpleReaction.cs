using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleReaction : MonoBehaviour
{
    // Drag the corresponding preform into the Inspector
    public GameObject FeCl3Beaker;    // FeCl3 beaker object
    public GameObject KSCNBeaker;     // KSCN beaker object
    public GameObject effectPrefab;  // Special effects preform
    public GameObject FeSCNProduct;   // Product beaker preform

    private bool hasReacted = false;  // Prevent repeated triggering

    void OnTriggerEnter(Collider other)
    {
        // Detect whether it is a collision between FeCl3 and KSCN
        if (!hasReacted && (other.gameObject == FeCl3Beaker || other.gameObject == KSCNBeaker))
        {
            TriggerReaction();
        }
    }

    void TriggerReaction()
    {
        hasReacted = true;

        // Step 1: Calculate the middle position
        Vector3 centerPos = (FeCl3Beaker.transform.position + KSCNBeaker.transform.position) * 0.5f;

        // Step 2: Play the special effects
        Instantiate(effectPrefab, centerPos, Quaternion.identity);

        // Step 3: Hide the original beaker
        FeCl3Beaker.SetActive(false);
        KSCNBeaker.SetActive(false);

        // Step 4: Display the product
        FeSCNProduct.transform.position = centerPos;
        FeSCNProduct.SetActive(true);
    }
}
