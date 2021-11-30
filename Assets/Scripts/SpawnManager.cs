using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    void Start()
    {
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }

    
    void Update()
    {
        
    }
}
