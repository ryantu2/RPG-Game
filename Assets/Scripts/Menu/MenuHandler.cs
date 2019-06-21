using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[AddComponentMenu("Village/Menu/Main Menu")]
public class MenuHandler : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {
        Time.timeScale = 1f;
        GameManager.isPaused = false;
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
         EditorApplication.isPlaying = false;
#endif
        Time.timeScale = 1f;
        GameManager.isPaused = false;
        Application.Quit();
    }
}
