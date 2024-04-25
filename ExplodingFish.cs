// Abir Mahmood
// CSC-350H
// Dr. Hao Tang
// HW-9

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DetonatingFish : AnimatedFish
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    public override void DestroyFish()
    {
        Debug.Log($"The detonating fish has been obliterated! Earned points: {pointValue}");

        animator.enabled = true;
        Destroy(gameObject, 2f);
    }

}
