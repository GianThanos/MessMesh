using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    public GameObject obstacles;
    Vector3 spawnPos;
    public Transform spawnerPoint;
    public float spawnRate;
    private float timeBtwSpawns;

    void Start()
    {
        timeBtwSpawns = spawnRate;
    }
    

    private void FixedUpdate()
    {
        if (timeBtwSpawns <= 0)
        {
            Instantiate(obstacles, spawnerPoint.position, transform.rotation);
            timeBtwSpawns = spawnRate;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

 
}
