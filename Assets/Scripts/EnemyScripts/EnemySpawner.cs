using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawnPosition;
    private float spawnRate = 5f;

    private void Update() {
        SpawnEnemy();
    }
    private void SpawnEnemy() {
        spawnRate -= Time.deltaTime;

        if(spawnRate < 0) {

            
            Instantiate(enemyPrefab, enemySpawnPosition.position,Quaternion.identity);

            
            spawnRate = 5f;
        }
    }
}
