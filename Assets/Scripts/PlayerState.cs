using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI healthText;

    private readonly float max_health = 100;
    private readonly float min_health = 0;

    private float health;

    private void Start()
    {
        health = max_health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
            GetDamage(5);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Void"))
            KillPlayer();
    }

    private void GetDamage(int damage)
    {
        health -= damage;

        if (health <= min_health)
            KillPlayer();

        healthText.text = $"Health: {health}";
    }

    private void KillPlayer()
    {
        SceneManager.LoadScene("Lose Screen");
    }
}
