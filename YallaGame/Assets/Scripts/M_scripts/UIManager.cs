using System;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PlayerHealth _PlayerHealth;
    public ScoreManager _ScoreManager;
    
    public TextMeshProUGUI hpTextField;
    public TextMeshProUGUI scoreTextField;

    private void Start()
    {
        UpdateUIScore();
        UpdateUIHP();
    }

    public void UpdateUIHP()
    {
        hpTextField.text = _PlayerHealth.currentHealth.ToString();
    }
    
    public void UpdateUIScore()
    {
        scoreTextField.text = _ScoreManager.playerScore.ToString();
    }
    
    
}
