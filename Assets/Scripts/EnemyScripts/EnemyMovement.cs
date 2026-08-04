using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] private Transform[] enemyPaths;
    [SerializeField] private float speed = 5f;

    int i = 0;
    private void Update() {
        Movement();
    }

    private void Movement() {
        Debug.DrawLine(transform.position, enemyPaths[i].position, Color.red);
        // 1. Move the enemy toward the current waypoint target
        Vector2 targetPosition = enemyPaths[i].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
        Debug.Log($"Enemy: {transform.position}");
        Debug.Log($"Target: {targetPosition}");
        // 2. Check if the enemy has reached the current waypoint
        if ((Vector2)transform.position == targetPosition) {

            // 3. Advance to the next waypoint
            Debug.Log("Reached: " + enemyPaths[i].name);
            i++;

            //4.Handle reaching the end of the path
            if (i >= enemyPaths.Length) {
                end();
            }
        }
    }
    private void end() {
        Destroy(gameObject);
        }
}