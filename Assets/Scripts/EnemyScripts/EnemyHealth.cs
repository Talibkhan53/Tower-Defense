using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int maxHealth = 100;
    int currentHealth = 100;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage();

        if (Input.GetKeyDown(KeyCode.S))
            IncreaseHealth();
    }

    void TakeDamage() {
        int damage = 20;
        currentHealth -= damage;

        Debug.Log(currentHealth);

        if(currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    void IncreaseHealth() {
        int health = 20;
        currentHealth += health;

        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;

        Debug.Log(currentHealth);
    }

}
