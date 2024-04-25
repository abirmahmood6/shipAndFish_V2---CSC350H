// Abir Mahmood
// CSC-350H
// Dr. Hao Tang
// HW-9

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a blast effect.
/// </summary>
public class Explosion : MonoBehaviour
{
    // Animator caching for performance optimization
    Animator blastAnimator;

    /// <summary>
    /// Invoked before the first frame update.
    /// </summary>
    void Start()
    {
        blastAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        // Check if the blast animation has completed and destroy the GameObject if so
        if (blastAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            //Destroy(gameObject);
        }
    }
}

