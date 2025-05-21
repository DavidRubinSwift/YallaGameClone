using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuMobile : MonoBehaviour
{
    // Reference to the pause menu UI panel in the scene
    public GameObject pausePanel;

    // This method is called to pause the game
    public void PauseGame()
    {
        // Activate the pause panel (make it visible)
        pausePanel.SetActive(true);

        // Freeze all in-game activity by setting time scale to 0
        Time.timeScale = 0f;
    }

    // This method is called to resume the game after pausing
    public void ResumeGame()
    {
        // Hide the pause panel (make it invisible)
        pausePanel.SetActive(false);

        // Resume normal game activity by setting time scale back to 1
        Time.timeScale = 1f;
    }

    // This method is called when the player wants to return to the main menu
    public void LoadMainMenu()
    {
        // Ensure time scale is reset to normal in case game was paused
        Time.timeScale = 1f;

        // Load the main menu scene by name
        SceneManager.LoadScene("MainMenuScene");
    }
}
