using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Transform[] enemyPaths;
    [SerializeField] private float speed = 5f;

    int i = 0;
    private void Update() {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("castle")) {
            end();
        }
    }
    private void Movement() {
        //Debug.DrawLine(transform.position, enemyPaths[i].position, Color.red);

        // 1. Move the enemy toward the current waypoint target
        Vector2 targetPosition = enemyPaths[i].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
       
        // 2. Check if the enemy has reached the current waypoint
        if ((Vector2)transform.position == targetPosition) {

            // 3. Advance to the next waypoint
            
            i++;

            //4.Handle reaching the end of the path
            if (i >= enemyPaths.Length) {
                end();
            }
        }
    }
    private void end() {
        Debug.Log("GameObject Destroyed");
        Destroy(gameObject);
        }

    public void SetPath(Transform[] path) {
        enemyPaths = path;
    }
}