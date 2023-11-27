using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
 Rigidbody player; 
 public float gravityScaler;
 public float jumpPower;
 public bool isGrounded = true;
 public bool gameOver = false; 


    void Start()
    {
        player = GetComponent<Rigidbody>();
        Physics.gravity *= gravityScaler;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
       {
        player.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        isGrounded = false; 
       }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
        {
             isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over! You Suck!");
        }
    }
}
