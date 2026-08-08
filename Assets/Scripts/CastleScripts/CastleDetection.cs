using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CastleDetection : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    private void Start() {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("enemy")) {
            Debug.Log("Enemy Entered Castle Range: " + collision.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("enemy")) {
            Debug.Log("Enemy Exited Castle Range: " + collision.gameObject.name);
        }
    }


}
