using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void NewGameButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void MaterialsButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
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
