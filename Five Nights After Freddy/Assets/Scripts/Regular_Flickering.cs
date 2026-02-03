using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regular_Flickering : MonoBehaviour
{
    private Light light;
    public float minIntensity = 0.2f;
    public float maxIntensity;
    public float flickerSpeed = 0.5f;

    private void Start()
    {
        light = GetComponent<Light>();
        maxIntensity = light.intensity;
        InvokeRepeating("Flicker", 0f, flickerSpeed);
    }

    // Light flickering
    private void Flicker()
    {
        if (light.intensity == minIntensity) { 
            light.intensity = maxIntensity;
        }
        else
        {
            light.intensity = minIntensity;
        }
    }
}
