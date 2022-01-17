using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifiar = 1;
    private bool isOnTheGround = true;
    public bool gameOver;
    private Animator playerAnimator;
    public ParticleSystem ExplosionParticleSystem;
    public ParticleSystem TierraParticleSystem;

    void Start()
    {
        gameOver = false;
        playerRigidbody = GetComponent<Rigidbody>();
        //playerRigidbody.AddForce(Vector3.up * jumpForce);
        Physics.gravity *= gravityModifiar;
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce);
            isOnTheGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            TierraParticleSystem.Stop();
        }

        
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if(!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                isOnTheGround = true;
                TierraParticleSystem.Play();
            }

            if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                int randomDeath = Random.Range(1, 3);
                playerAnimator.SetBool("Death_b", true);
                playerAnimator.SetInteger("DeathType_int", randomDeath);

                /*ParticleSystem explosionEscena = 
                Vector3 offset = new Vector3(0, 1.5, 0);
                Instantiate(ExplosionParticleSystem, 
                            transform.position + offset, 
                    ExplosionParticleSystem.transform.rotation);
                */
                ExplosionParticleSystem.Play();
                TierraParticleSystem.Stop();
            }
        }
        
    }
}
