using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float leftLim = -10f;

    void Update()
    {
        if (transform.position.x < leftLim)
        {
            Destroy(gameObject);
        }
    }
}
