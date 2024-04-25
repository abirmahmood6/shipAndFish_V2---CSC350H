// Abir Mahmood
// CSC-350H
// Dr. Hao Tang
// HW-9


using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    // Reference to the fish collector component
    private AquaticHarvester aquaticHarvester;

    // The current target being pursued
    private GameObject currentTarget;

    // The direction of movement towards the target
    private Vector2 movementDirection;

    // Reference to the rigidbody component for movement
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        aquaticHarvester = Camera.main.GetComponent<AquaticHarvester>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add any update logic here
    }

    // Triggered when the user clicks on the vessel
    void OnMouseDown()
    {
        FindNearestTarget();
    }

    // Triggered when the vessel stays within a collider
    void OnTriggerStay2D(Collider2D other)
    {
        AquaticCreature creature = other.gameObject.GetComponent<AquaticCreature>();
        if (creature != null)
        {
            creature.DestroyCreature();
            aquaticHarvester.RemoveCreatureFromList(creature.gameObject);
            Debug.Log("Aquatic Creature Captured at: " + creature.gameObject.transform.position);
        }
        OnMouseDown();
    }

    // Finds the nearest target for the vessel to pursue
    void FindNearestTarget()
    {
        float nearestDistance = Mathf.Infinity;
        rigidBody.velocity = Vector2.zero;

        foreach (GameObject creature in aquaticHarvester.aquaticCreatureList)
        {
            float distanceToCreature = Vector3.Distance(transform.position, creature.transform.position);

            if (distanceToCreature < nearestDistance)
            {
                nearestDistance = distanceToCreature;
                currentTarget = creature;
            }
        }

        if (currentTarget != null)
        {
            movementDirection = new Vector2(currentTarget.transform.position.x - transform.position.x, currentTarget.transform.position.y - transform.position.y);
            rigidBody.AddForce(movementDirection, ForceMode2D.Impulse);
            Debug.Log("Target Position: " + currentTarget.transform.position);
            Debug.DrawLine(currentTarget.transform.position, transform.position, Color.green, 100f);
        }
    }
}
