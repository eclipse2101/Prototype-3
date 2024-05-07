using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI; 

public class ScoreScript : MonoBehaviour
{
    public int score = 1;
     private PlayerScript PC; 
     public TextMeshProUGUI textScore; 
     public float timer;

    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("Player").GetComponent<PlayerScript>();
        timer = 0;
        textScore.text = "Score:" + 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (PC.gameOver == false)
        {
            timer += Time.deltaTime;
        
           if(timer > 1)
         {
            timer = 0;

            if(PC.isRunning == true)
          {
            score = score + 2;
            textScore.text = "Score:" + score;
            Debug.Log("the score is boosted");
          }
            else
          {
            score = score + 1;
            textScore.text = "Score:" + score;
            Debug.Log("the score is not boosted");
          }
            
         }
        }
        
        
       ////////////////////// 
        
        

    }
}
