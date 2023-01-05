using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool secondJump;
    public bool gameOver = false;
    



    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        playerAnim= GetComponent<Animator>();
        playerAudio= GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            if (isOnGround)
            {
                playerRb.velocity = Vector3.up * jumpForce;
                isOnGround = false;
                secondJump = true;
                playerAnim.SetTrigger("Jump_trig");
                playerAudio.PlayOneShot(jumpSound, 1f);
                playerAnim.SetBool("Grounded", false);

            }


            else if (secondJump)
            {
                playerRb.velocity = Vector3.up * jumpForce;
                playerAnim.SetTrigger("Jump_trig");
                playerAudio.PlayOneShot(jumpSound, 2f);
                secondJump = false;
                playerAnim.SetBool("bb", true);

            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            secondJump = false;
            dirtParticle.Play();
            playerAnim.SetBool("Grounded", true);
            playerAnim.SetBool("bb", false);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAnim.SetTrigger("Death_b");
            playerAudio.PlayOneShot(crashSound, 1f);
            Debug.Log("Game Over!");
            gameOver= true;
        }
    }
}
