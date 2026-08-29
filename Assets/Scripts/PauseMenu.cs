using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool _pause;
    public GameObject _pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pause = !_pause;
        }
        if (_pause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ResumeButton()
    {
        _pause = !_pause;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
                // ¬ редакторе Unity - останавливаем воспроизведение
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    // ¬ собранной игре - закрываем приложение
                    Application.Quit();
        #endif
    }
}
