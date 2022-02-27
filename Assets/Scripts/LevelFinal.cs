using UnityEngine;

public class LevelFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            LevelManager.Instance.LoadNextLevel();
    }
}
