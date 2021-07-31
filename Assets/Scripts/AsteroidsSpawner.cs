using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public int spawnAmount = 2;
    private void Start() {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn() {
        if (GameObject.FindGameObjectsWithTag("Asteroid").Length == 0) {
            for (int i = 0; i < spawnAmount; i++) {
                Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
                Vector3 spawnPoint = this.transform.position + spawnDirection;
                float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

                Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);

                if (spawnAmount == 2) {
                    asteroid.size = asteroid.maxSize;
                } else {
                    asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
                }
                
                asteroid.SetTrajectory(rotation * -spawnDirection);
            } 
        spawnAmount++;
        }  
    }                              
}
