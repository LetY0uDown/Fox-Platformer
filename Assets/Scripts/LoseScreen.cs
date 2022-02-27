using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public void RestartGame()
    {
        LevelManager.Instance.LoadCurrentLevel();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
