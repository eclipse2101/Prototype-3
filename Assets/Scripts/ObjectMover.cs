using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private float speed = 30;
    float leftBound = -15;
    private PlayerScript PC; 
    
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("Player").GetComponent<PlayerScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(PC.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); 
        }
    }
}
