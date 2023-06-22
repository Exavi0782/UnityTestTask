using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] Transform cubeSpawnPoint;
    [SerializeField] GameObject cubePrefab;
    float time = 0.0f;
    bool isCubeSpawned = true;
    GameObject spawnedCube;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube")) { 
            isCubeSpawned = true;
            time = 0.25f;    
        }
    }
    void Update()
    {
        if (isCubeSpawned)
        {
            
            if (time <= 0)
            {
                Vector3 point = cubeSpawnPoint.position;
                spawnedCube = Instantiate(cubePrefab, point, cubeSpawnPoint.rotation);
                isCubeSpawned = false;
            }
            else time -= Time.deltaTime;
        }
    }


}