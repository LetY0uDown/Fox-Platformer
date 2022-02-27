using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                Resume();
            else
                Pause();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    private void Pause()
    {
        isGamePaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        isGamePaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }
}
