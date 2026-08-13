using System.Collections.Generic;
using UnityEngine;
public class CastleDetection : MonoBehaviour
{
    private float attackTime = 1f;
    private GameObject currentTarget;
    private int attackDamage = 50;
    private List<GameObject> enemiesInRange =  new List<GameObject>();

    private void Update() {
        SelectTarget();
        Attack();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("enemy")) {
            //Debug.Log("Enemy Entered Castle Range: " + collision.gameObject.name);
            currentTarget = collision.gameObject;
            enemiesInRange.Add(collision.gameObject);
            //Debug.Log("Current Target:"+currentTarget.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("enemy")) {
            Debug.Log("Enemy Exited Castle Range: " + collision.gameObject.name);
            enemiesInRange.Remove(collision.gameObject);

            if(currentTarget==collision.gameObject) {
                Debug.Log("Current Target Removed:"+currentTarget.name);
                currentTarget = null;
            }
        }
    }
   
    void SelectTarget() {
        if(enemiesInRange.Count > 0) {
            currentTarget = enemiesInRange[0];
        }
        else {
            currentTarget = null;
        }
    }
    void Attack() {
        attackTime -= Time.deltaTime;
        if (attackTime <= 0) {
            if (currentTarget != null) {
                Debug.Log("Hitted The Enemy:" + currentTarget);
                EnemyHealth enemyHealth = currentTarget.GetComponent<EnemyHealth>();

                if(enemyHealth != null) {
                    enemyHealth.TakeDamage(attackDamage);
                }

                attackTime = 1f;
            }
        }
    }
}
