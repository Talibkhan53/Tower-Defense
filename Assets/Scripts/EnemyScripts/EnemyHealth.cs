using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int enemyReward = 20;
    [SerializeField] private  PlayerEconomySystem economySystem;

    private int currentHealth;

    private void Start() {
        economySystem = FindFirstObjectByType<PlayerEconomySystem>();
        currentHealth = maxHealth;
    }

    private void Update() {
        // Testing only
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
        }

        // Testing only
        if (Input.GetKeyDown(KeyCode.S)) {
            IncreaseHealth();
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        Debug.Log("Enemy Health: " + currentHealth + "/" + maxHealth);

        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        economySystem.AddCoins(enemyReward);

        Destroy(gameObject);
    }

    private void IncreaseHealth() {
        int health = 20;

        currentHealth += health;

        if (currentHealth >= maxHealth) {
            currentHealth = maxHealth;
        }

        Debug.Log("Enemy Health: " + currentHealth + "/" + maxHealth);
    }
}