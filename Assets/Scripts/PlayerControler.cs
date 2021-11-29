using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifiar = 1;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.AddForce(Vector3.up * jumpForce);
        Physics.gravity *= gravityModifiar;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
