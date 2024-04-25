// Abir Mahmood
// CSC-350H
// Dr. Hao Tang
// HW-9

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MarineCollector : MonoBehaviour
{

    [SerializeReference] GameObject marinePrefab;
    public List<GameObject> marineList = new List<GameObject>();

    [SerializeReference] GameObject explosiveMarinePrefab;
    [SerializeReference] GameObject fieryMarinePrefab;
    [SerializeReference] GameObject commonMarinePrefab;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            DeployRandomMarine();
        }
    }

    void DeployRandomMarine()
    {
        GameObject[] marinePrefabs = { commonMarinePrefab, explosiveMarinePrefab, fieryMarinePrefab };
        int randomIndex = Random.Range(0, marinePrefabs.Length);
        DeployMarine(marinePrefabs[randomIndex]);
    }

    void DeployMarine(GameObject marinePrefab)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        GameObject marine = Instantiate(marinePrefab, worldPosition, Quaternion.identity);
        marineList.Add(marine);
    }


    public void RemoveMarineFromList(GameObject marine)
    {
        if (marineList.Contains(marine))
        {
            marineList.Remove(marine);
        }
    }

}
