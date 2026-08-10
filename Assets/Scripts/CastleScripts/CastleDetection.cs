using UnityEngine;
public class CastleDetection : MonoBehaviour
{
    private float attackTime = 1f;
    private GameObject currentTarget;
    private int attackDamage = 50;
    private void Update() {
        Attack();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("enemy")) {
            //Debug.Log("Enemy Entered Castle Range: " + collision.gameObject.name);
            currentTarget = collision.gameObject;
            //Debug.Log("Current Target:"+currentTarget.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("enemy")) {
            Debug.Log("Enemy Exited Castle Range: " + collision.gameObject.name);

            if(currentTarget==collision.gameObject) {
                Debug.Log("Current Target Removed:"+currentTarget.name);
                currentTarget = null;
            }
        }
    }
   
    void Attack() {
        attackTime -= Time.deltaTime;
        if (attackTime <= 0) {
            if (currentTarget!=null) {
                Debug.Log("Hitted The Enemy:" + currentTarget);
                currentTarget.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                attackTime = 1f;
            }
        }
    }
}
