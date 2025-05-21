using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public ScoreManager _ScoreManager;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _ScoreManager.AddScore();
            
            other.gameObject.SetActive(false); // будет заменен на метод из пула

        }
    }
}
