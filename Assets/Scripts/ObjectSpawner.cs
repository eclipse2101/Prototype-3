using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    float SpawnRangeX = 39;
    
    public float startingSpawn = 5; 
    public float spawnTiming = 1.5f;
    private PlayerScript PC; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacles", startingSpawn, spawnTiming);
        PC = GameObject.Find("Player").GetComponent<PlayerScript>(); 
    }

    void SpawnRandomObstacles()

    {
            Vector3 spawnPos = new Vector3(SpawnRangeX, 0.4f, 0); 
            
            int objectIndex = Random.Range(0, objectPrefabs.Length); 
       
        
       
       if (PC.gameOver == false)
       {
            Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);
       } 
    }
}
