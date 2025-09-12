using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public GameObject prefab; // the thing to spawn
    public float startTime; // when to spawn
    public float endTime; // when to stop spawning
    public float spawnRate; // the rate at which to spawn

    void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }

    void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
