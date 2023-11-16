using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    float SpawnRangeX = 39;
    
    public float startingSpawn = 5; 
    public float spawnTiming = 1.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacles", startingSpawn, spawnTiming);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomObstacles()

    {
        
        Vector3 spawnPos = new Vector3(SpawnRangeX, 0, 0); 
            
            int objectIndex = Random.Range(0, objectPrefabs.Length); 
            
            Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);

    }
}
