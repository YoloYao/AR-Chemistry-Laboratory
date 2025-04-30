using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalReaction : MonoBehaviour
{
    public GameObject reactionEffect; // Drag in the particle effect preform
    public GameObject productPrefab;  // Drag in the NaCl molecular preform

    void OnTriggerEnter(Collider other) {
        // Determine whether it is a collision between sodium and chlorine
        if ((gameObject.CompareTag("Na") && other.CompareTag("Cl")) ||
            (gameObject.CompareTag("Cl") && other.CompareTag("Na"))) {
            
            // Play particle special effects
            Instantiate(reactionEffect, transform.position, Quaternion.identity);

            // Generate new molecules (with positions at the midpoint)
            Vector3 spawnPos = (transform.position + other.transform.position) / 2;
            Instantiate(productPrefab, spawnPos, Quaternion.identity);

            // Destroy the original atom
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
