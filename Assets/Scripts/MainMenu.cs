using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button continue_button;

    [SerializeField]
    private Button levels_button;

    private void Awake()
    {
        var isStartedPlaying = PlayerPrefs.GetString("StartedPlaying", "false");

        if (isStartedPlaying == "true")
            continue_button.interactable = true;
        else
            continue_button.interactable = false;
    }

    public void ContinueGame()
    {
        LevelManager.Instance.LoadCurrentLevel();
    }

    public void ShowLevels()
    {
        SceneManager.LoadScene("Levels List");
        PlayerPrefs.SetString("StartedPlaying", "true");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
