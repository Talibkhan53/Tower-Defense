using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] enemyPaths;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawnPosition;
    private float spawnRate = 5f;

    private void Update() {
        SpawnEnemy();
    }
    private void SpawnEnemy() {
        spawnRate -= Time.deltaTime;

        if(spawnRate <= 0) {
            Debug.Log("Trying to Spawn");
           GameObject  enemy = Instantiate(enemyPrefab, enemySpawnPosition.position,Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetPath(enemyPaths);
            spawnRate = 5f;
            Debug.Log("Spawned: " + enemyPrefab.name);
        }
    }
}
