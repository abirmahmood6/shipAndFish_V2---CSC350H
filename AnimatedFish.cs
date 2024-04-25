// Abir Mahmood
// CSC-350H
// Dr. Hao Tang
// HW-9

using System.Diagnostics;
using UnityEngine;

public abstract class AnimatedFish : Fish
{
    // Holds a reference to the animated fish prefab GameObject
    public GameObject PrefabAnimation;


    public override void DestroyFish()
    {

        Debug.Log($"Animated fish has been removed! Points awarded: {pointValue}");


        Destroy(gameObject);
    }
}
