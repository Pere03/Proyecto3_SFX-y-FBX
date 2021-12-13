using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    public float startDelay = 2f;
    public float repeatRate = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObject",startDelay,repeatRate);
       
    }


    void Update()
    {

    }

    public void SpawnObject()
    {
       Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }
}
