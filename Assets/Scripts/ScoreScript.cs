using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int score = 1;
     private PlayerScript PC; 

    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("Player").GetComponent<PlayerScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(PC.isRunning == true)
        {
            score = 2;
            Debug.Log("the score is boosted");
        }
        else
        {
            score = 1;
            Debug.Log("the score is not boosted");
        }
    }
}
