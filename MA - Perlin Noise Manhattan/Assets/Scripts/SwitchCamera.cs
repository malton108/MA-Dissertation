using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script takes two camera objects that the user can switch between to observe the generated city
 */
public class SwitchCamera : MonoBehaviour
{
    // Take the two cameras to switch between
    public Camera cameraOne;
    public Camera cameraTwo;

    // Start by enabling cameraOne
    void Start()
    {
        cameraOne.enabled = true;
        cameraTwo.enabled = false;
    }

    // Switch between cameras
    void Update()
    {
        // If space is pressed, swap camera
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraOne.enabled = !cameraOne.enabled;
            cameraTwo.enabled = !cameraTwo.enabled;
        }
    }
}
