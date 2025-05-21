/*using System;
using UnityEngine;
using System.Collections.Generic;

public class CoinPooler : MonoBehaviour
{
    // Prefab of the coin that will be instantiated and pooled
    public GameObject coinPrefab;
    
    // Total number of coins to be created and stored in the pool
    public int coinAmount = 20;

    // Internal list to store pooled coin objects
    private List<GameObject> coinPool;

    void Start()
    {
        // Create the coin pool when the game starts
        CreatePool();
    }

    // Method to initialize the coin pool
    public void CreatePool()
    {
        coinPool = new List<GameObject>();

        for (int i = 0; i < coinAmount; i++)
        {
            // Instantiate a new coin from the prefab
            GameObject newCoin = Instantiate(coinPrefab);

            // Immediately deactivate the coin and return it to the pool
            ReturnToPool(newCoin);

            // Add the coin to the pool
            coinPool.Add(newCoin);
        }
    }

    // Method to get an available coin from the pool
    public GameObject GetFromPool()
    {
        for (int i = 0; i < coinPool.Count; i++)
        {
            // Look for an inactive (available) coin
            if (!coinPool[i].activeInHierarchy)
            {
                // Activate the coin before using it
                coinPool[i].SetActive(true);
                return coinPool[i];
            }
        }

        // If no inactive coin is found, return null
        return null;
    }

    // Method to return a coin to the pool (deactivating it)
    public void ReturnToPool(GameObject gmObj)
    {
        gmObj.SetActive(false);
    }
}

*/

