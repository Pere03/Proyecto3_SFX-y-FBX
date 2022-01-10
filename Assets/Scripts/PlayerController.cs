using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifiar = 1;
    private bool isOnTheGround = true;
    public bool gameOver;

    void Start()
    {
        gameOver = false;
        playerRigidbody = GetComponent<Rigidbody>();
        //playerRigidbody.AddForce(Vector3.up * jumpForce);
        Physics.gravity *= gravityModifiar;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
            isOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }

        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }
    }
}
