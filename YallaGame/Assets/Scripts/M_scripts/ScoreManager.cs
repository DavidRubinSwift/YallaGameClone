using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public UIManager _UIManager;
    
    public int playerScore = 0;
    public int coinScore = 100;
    
    public void AddScore()
    {
        playerScore += coinScore;
        _UIManager.UpdateUIScore();
        
    }
}
