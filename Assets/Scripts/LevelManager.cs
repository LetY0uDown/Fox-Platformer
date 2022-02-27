using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private LevelManager() { }
    private static LevelManager instance;
    public static LevelManager Instance => instance;

    private Level current_level;

    [SerializeField]
    private List<Level> levels;

    private void Awake()
    {
        instance = this;

        var level = PlayerPrefs.GetInt("CurrentLevelID", 1);
        SetCurrentLevel(level);

        SceneManager.sceneLoaded += UpdateButtons;
    }

    private void UpdateButtons(Scene scene, LoadSceneMode loadMode)
    {
        if (scene.name == "Levels List")
            foreach (Level level in levels)
                level.UpdateButtonState();
    }

    public void LoadCurrentLevel()
    {
        current_level.LoadLevel();
    }

    public void LoadNextLevel()
    {
        SetCurrentLevel(current_level.id + 1);
        LoadCurrentLevel();
    }

    public void SetCurrentLevel(int id)
    {
        PlayerPrefs.SetInt("CurrentLevelID", id);
        current_level = levels[id - 1];
    }
}
