using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Flickering : MonoBehaviour
{
    private Light light;
    public float minIntensity = 0.2f;
    public float maxIntensity = 4f;
    public float flickerSpeed = 1f;

    private void Start()
    {
        light = GetComponent<Light>();
        InvokeRepeating("Flicker", 0f, flickerSpeed);
    }

    // Light flickering
    private void Flicker_regular()
    {
        float randomIntensity = Random.Range(minIntensity, maxIntensity);
        light.intensity = randomIntensity;
    }
}
