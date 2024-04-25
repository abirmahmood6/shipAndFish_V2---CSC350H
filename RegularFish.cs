// Abir Mahmood
// CSC-350H
// Dr. Hao Tang
// HW-9

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularFish : Fish
{
 
    public override void DestroyFish()
    {

        Debug.Log($" The regular fish destroyed! Earned Points!: {pointValue}");

        Destroy(gameObject);
    }
}
