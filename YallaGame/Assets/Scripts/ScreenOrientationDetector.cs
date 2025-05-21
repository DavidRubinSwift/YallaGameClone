using System;
using UnityEngine;

public class ScreenOrientationDetector : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        // Get the current acceleration vector from the device's accelerometer
        Vector3 acceleration = Input.acceleration;

        // Log the raw acceleration vector to the console for debugging
        Debug.Log(acceleration);

        // Check if the horizontal acceleration is greater than the vertical
        if (acceleration.x > acceleration.y)
        {
            // Log message indicating the orientation is more horizontal (e.g., landscape)
            Debug.Log("position1");
        }
        else
        {
            // Log message indicating the orientation is more vertical (e.g., portrait)
            Debug.Log("position2");
        }
    }
}