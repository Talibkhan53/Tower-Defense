using UnityEngine;
public class CastleHealth : MonoBehaviour
{
    private float castleCurrentHealth = 10f;
    private float castleMaxHealth = 10f;
    private float takeDamage = 1f;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("enemy")) {
        castleCurrentHealth -= takeDamage;
        Debug.Log(castleCurrentHealth);
    }
    Debug.Log("Castle hit by: " + collision.gameObject.tag);
        Health();
    }

    private void Health() {
        if(castleCurrentHealth <= 0) {
            Destroy(gameObject);
        }
    }

}
