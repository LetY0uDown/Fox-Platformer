using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            BackToMenu();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
