using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Button level_button;

    public bool IsOpened => id <= PlayerPrefs.GetInt("CurrentLevelID");

    public int id;

    public void UpdateButtonState()
    {
        level_button.interactable = IsOpened;
    }

    public void LoadLevel()
    {
        LevelManager.Instance.SetCurrentLevel(id);
        SceneManager.LoadScene($"Level {id}");
    }
}
