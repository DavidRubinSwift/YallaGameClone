using System.Collections.Generic;
using UnityEngine;

public class ObsticalPoolGenerator : MonoBehaviour
{
    public GameObject obstical;

    public int amountOfObstical = 10; // поменял на 10 с 40 

    private List<GameObject> obsticalS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        CreatePool();
    }

    public void CreatePool()
    {
        obsticalS = new List<GameObject>();
        
        for (int i = 0; i < amountOfObstical; i++)
        {
            GameObject newObstical = Instantiate(obstical);
            ReturnToPool(newObstical);
            obsticalS.Add(newObstical);
        }
    }

    public GameObject GetPoolObject()
    {
        for (int i = 0; i < obsticalS.Count; i++)
        {
            if (!obsticalS[i].activeInHierarchy)
            {
                obsticalS[i].SetActive(true); // активируем перед использованием
                
                return obsticalS[i];
            }
        }
        return null;
    }

    public void ReturnToPool(GameObject poolObject)
    {
        poolObject.SetActive(false);
    }


}
