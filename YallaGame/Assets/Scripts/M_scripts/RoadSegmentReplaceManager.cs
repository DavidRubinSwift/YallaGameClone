using UnityEngine;
using System.Collections.Generic;

public class RoadSegmentReplaceManager : MonoBehaviour
{
    // Parent object that holds all road block segments
    public Transform roadParent;

    // Reference to the obstacle pool system
    public ObsticalPoolGenerator _ObsticalPoolGenerator;

    // Flag to avoid spawning obstacles on two consecutive road blocks
    private bool wasObstacleSpawnedLastTime = false;

    private void OnTriggerEnter(Collider other)
    {
        // If the collider belongs to an obstacle, return it to the pool
        if (other.CompareTag("ObstacleCube"))
        {
            _ObsticalPoolGenerator.ReturnToPool(other.gameObject);
            return;
        }

        // Skip processing if we already spawned an obstacle last time
        if (wasObstacleSpawnedLastTime)
        {
            wasObstacleSpawnedLastTime = false;
            return;
        }

        // If the collider is a road block
        if (other.CompareTag("RoadBlock"))
        {
            // Find the road block that is farthest along the Z axis
            float maxZ = -1;
            foreach (Transform block in roadParent)
            {
                if (block.position.z > maxZ)
                    maxZ = block.position.z;
            }

            // Move the current block to the end of the road (after the farthest block)
            Vector3 newPos = new Vector3(
                other.transform.position.x,
                other.transform.position.y,
                maxZ + 1 // move it one unit forward along Z
            );

            other.transform.position = newPos;

            // With 30% chance, place an obstacle on this block
            if (Random.value <= 0.3f)
            {
                PlaceObstacle(other.transform);
                wasObstacleSpawnedLastTime = true;
            }
        }
    }

    // Places an obstacle on a valid spawn point inside the given road block
    private void PlaceObstacle(Transform roadBlock)
    {
        // Find all child transforms (including nested ones)
        Transform[] localSpawnPoints = roadBlock.GetComponentsInChildren<Transform>();
        var validPoints = new List<Transform>();

        // Filter spawn points by name (starts with "SpawnPoint")
        foreach (Transform t in localSpawnPoints)
        {
            if (t.name.StartsWith("SpawnPoint"))
            {
                validPoints.Add(t);
            }
        }

        // If no valid spawn points found, do nothing
        if (validPoints.Count == 0) return;

        // Get a free obstacle from the pool
        GameObject myObstacle = _ObsticalPoolGenerator.GetPoolObject();
        if (myObstacle == null)
        {
            Debug.LogWarning("No free obstacles available in pool.");
            return;
        }

        // Pick a random spawn point and place the obstacle there
        int index = Random.Range(0, validPoints.Count);
        myObstacle.transform.position = validPoints[index].position;
    }
}
