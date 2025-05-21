using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

// This script toggles sound on/off and updates button text accordingly
public class SoundToggle : MonoBehaviour
{
    public Button toggleButton;           // Reference to the UI Button component
    public TMP_Text buttonText;           // Reference to the button's text (TextMeshPro)

    private bool isMuted = false;         // Boolean flag to track mute state

    void Start()
    {
        // Set initial sound state and update button text
        UpdateSoundState();

        // Add listener to call ToggleSound() when the button is clicked
        toggleButton.onClick.AddListener(ToggleSound);
    }

    // This method toggles the sound state between ON and OFF
    public void ToggleSound()
    {
        // Flip the mute state
        isMuted = !isMuted;

        // Set the global audio volume accordingly
        AudioListener.volume = isMuted ? 0f : 1f;

        // Update the button's displayed text
        UpdateSoundState();
    }

    // This method updates the button text based on whether sound is muted or not
    private void UpdateSoundState()
    {
        if (buttonText != null)
        {
            // Change the text to indicate current sound status
            buttonText.text = isMuted ? "Sound: OFF" : "Sound: ON";
        }
    }
}