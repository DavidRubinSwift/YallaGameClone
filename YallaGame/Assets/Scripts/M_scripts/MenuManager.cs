using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene"); 
    }
    
    public void LoadMikeScene()
    {
        SceneManager.LoadScene("Mike"); 
    }

   
    public void LoadDavidScene()
    {
        SceneManager.LoadScene("David"); 
    }

    // Выход из игры или Play Mode
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // выход из Play Mode
#else
        Application.Quit(); // выход из билда
#endif
    }
}