// Abir Mahmood
// CSC-350H
// Dr. Hao Tang
// HW-9

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class FlamingFish : AnimatedFish
{
    public float CombustingDuration = 5f;
    private float combustionTimer;

    Animator animator;

    // A reference to the prefab for the fiery effect. Assign this in the Inspector.
    public GameObject fieryEffectPrefab;
    private GameObject currentFieryEffect;

    void Start()
    {
        // Setting the combustionTimer to the specified duration
        combustionTimer = CombustingDuration;

        // Creating the fiery effect and attaching it to the fish
        if (fieryEffectPrefab != null)
        {
            currentFieryEffect = Instantiate(fieryEffectPrefab, transform.position, Quaternion.identity, transform);
        }
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    void Update()
    {
        // Decreasing the combustion timer if the fish is still burning
        if (combustionTimer > 0)
        {
            combustionTimer -= Time.deltaTime;
        }
        else
        {
            // If the combustion timer runs out, the fish is destroyed
            //DestroyFish();
        }
    }

    // Overriding the DestroyFish method to include the flaming behavior
    public override void DestroyFish()
    {
        // Removing the fiery effect upon fish destruction
        if (currentFieryEffect != null)
        {
            Destroy(currentFieryEffect);
        }

        Debug.Log($"The flaming fish has been extinguished! Points awarded: {pointValue}");

        animator.enabled = true;
        // Destroying the fish GameObject itself with a delay
        Destroy(gameObject, 2f);
    }

}
