using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public UIManager _UIManager;
    public ObsticalPoolGenerator _ObsticalPoolGenerator;
    public PlayerSettings _PlayerSettings;
    
    public int currentHealth;

    public string sceneTOReload = "Mike";

    private const int damage = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = _PlayerSettings.playerMaxHealth;
        //_UIManager.UpdateUIHP();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObstacleCube"))
        {
            TakeDamage();
            _ObsticalPoolGenerator.ReturnToPool(other.gameObject);
        }

        if (other.CompareTag("Pill"))
        {
            Heal();
        }
    }

    private void Heal()
    {
        currentHealth++;
        if (currentHealth >=3)
        {
            currentHealth = 3;
        }
        _UIManager.UpdateUIHP();
        Debug.Log($"Curent health is {currentHealth}");
    }

    private void TakeDamage()
    {
        currentHealth -= damage;
        _UIManager.UpdateUIHP();
        Debug.Log($"Curent health is {currentHealth}");
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            SceneManager.LoadScene(sceneTOReload);
        }
    }
    
}
