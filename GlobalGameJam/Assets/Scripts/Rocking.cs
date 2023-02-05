using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocking : MonoBehaviour
{
    // Private Variables
    private float elapsedTime = 0f;

    // Public variables
    public float frequency = 1.0f;
    public float magnitude = 0.1f;
    void FixedUpdate()
    {
        // have the scale increase for half a second
        if (elapsedTime < frequency)
        {
            transform.Rotate(0f, 0f, magnitude);
        }
        // have the scale decrease for half a second
        else if (elapsedTime < frequency * 2)
        {
            transform.Rotate(0f, 0f, -magnitude);
        }
        // set isJumping to false
        else 
        {
            elapsedTime = 0;
        }

        elapsedTime += Time.deltaTime;
    }
}
