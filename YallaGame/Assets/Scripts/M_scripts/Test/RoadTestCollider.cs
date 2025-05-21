using UnityEngine;
using System.Collections.Generic;

/*
 * This class manages the endless road system by recycling road blocks
 * and spawning obstacles on them.
 */
public class RoadTestCollider : MonoBehaviour
{
    // Parent transform containing all road blocks
    public Transform roadParent;
    
    // Reference to obstacle pool generator for spawning obstacles
    public ObsticalPoolGenerator _ObsticalPoolGenerator;
    
    // Player transform for distance comparison
    public Transform player;
    
    // Distance threshold after which blocks are considered outdated and need recycling
    public float recycleDistance = 10f;
    
    // Flag to control obstacle spawning frequency (every other block)
    private bool wasObstacleSpawnedLastTime = false;

    /*
     * Update checks each frame if any road blocks need to be recycled
     * based on their distance from the player
     */
    private void Update()
    {
        foreach (Transform block in roadParent)
        {
            if (player.position.z - block.position.z > recycleDistance)
            {
                ReplaceBlock(block);
            }
        }
    }

    /*
     * Handles the recycling of a road block by:
     * 1. Finding the furthest Z position among all blocks
     * 2. Moving the recycled block beyond that position
     * 3. Potentially spawning an obstacle on the new block
     */
    private void ReplaceBlock(Transform block)
    {
        // Найдём максимальный Z среди всех блоков
        float maxZ = -1;
        foreach (Transform b in roadParent)
        {
            if (b.position.z > maxZ)
                maxZ = b.position.z;
        }

        Vector3 newPos = new Vector3(block.position.x, block.position.y, maxZ + 1);
        block.position = newPos;

        // Спаун препятствия через один блок с вероятностью 30%
        if (wasObstacleSpawnedLastTime)
        {
            wasObstacleSpawnedLastTime = false;
            return;
        }

        if (Random.value <= 0.3f)
        {
            PlaceObstacle(block);
            wasObstacleSpawnedLastTime = true;
        }
    }

    /*
     * Places an obstacle on a road block at one of its valid spawn points
     * Uses object pooling for better performance
     */
    private void PlaceObstacle(Transform roadBlock)
    {
        Transform[] localSpawnPoints = roadBlock.GetComponentsInChildren<Transform>();
        var validPoints = new List<Transform>();
        foreach (Transform t in localSpawnPoints)
        {
            if (t.name.StartsWith("SpawnPoint"))
            {
                validPoints.Add(t);
            }
        }

        if (validPoints.Count == 0) return;

        GameObject myObstacle = _ObsticalPoolGenerator.GetPoolObject();
        if (myObstacle == null)
        {
            Debug.LogWarning("No free obstacles available in pool.");
            return;
        }

        int index = Random.Range(0, validPoints.Count);
        myObstacle.transform.position = validPoints[index].position;
    }

    /*
     * Handles collision with obstacles to return them to the pool
     * when they're no longer needed
     */
    private void OnTriggerEnter(Collider other)
    {
        // Обработка возврата препятствий в пул
        if (other.CompareTag("ObstacleCube"))
        {
            _ObsticalPoolGenerator.ReturnToPool(other.gameObject);
        }
    }
}