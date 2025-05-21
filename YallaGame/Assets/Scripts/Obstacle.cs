using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Update()
    {
        // Check if the obstacle has moved behind the player or off-screen
        // In this case, if its Z position is less than -10
        if (transform.position.z < -10f)
        {
            // Deactivate the obstacle so it can be reused later by the object pool
            gameObject.SetActive(false);
        }
    }
}