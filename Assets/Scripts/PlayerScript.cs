using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
 Rigidbody player; 
 public float gravityScaler;
 public float jumpPower;
 public float doubleJumpPower;
 public bool isGrounded = true;
 public bool gameOver = false; 
 private Animator playeranim;
 public ParticleSystem BoomBoomParticle; 
 public ParticleSystem DirtTrail;
 private AudioSource playerAudio;
 public AudioClip jumpSound; 
 public AudioClip crashSound;
 public int jumps = 2;
 public bool isRunning;  
 public float animationspeed = 60;  


    void Start()
    {
        player = GetComponent<Rigidbody>();
        Physics.gravity *= gravityScaler;
        playeranim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
       ////////////////// JUMPING///////////////////
       if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
       {
        player.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        isGrounded = false; 
        playeranim.SetTrigger("Jump_trig");
        DirtTrail.Stop();
        playerAudio.PlayOneShot(jumpSound, 1.0f);
       }

       else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && !gameOver)
       {
         if(jumps != 0)
         {
          player.AddForce(Vector3.up * doubleJumpPower, ForceMode.Impulse);
          playeranim.SetTrigger("Jump_trig");
          DirtTrail.Stop();
          playerAudio.PlayOneShot(jumpSound, 1.0f);
          jumps = jumps - 1;
         }
       } 
       /////////////////RUNNING/////////////
       if(Input.GetKeyDown(KeyCode.LeftShift))
       {
         isRunning = true;
         playeranim.speed = animationspeed;
         Debug.Log("the player is running");
       }
      
      if(Input.GetKeyUp(KeyCode.LeftShift)) 
       {
        isRunning = false;
        playeranim.speed = 1;
        Debug.Log("the player is not running");
       }

    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
        {
             isGrounded = true;
             DirtTrail.Play();
             jumps = 2;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over! You Suck!");
            playeranim.SetBool("Death_b", true); 
            playeranim.SetInteger("DeathType_int", 1);
            BoomBoomParticle.Play();
            DirtTrail.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f); 
        }
    }
}
