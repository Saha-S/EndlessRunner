using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public Transform point;
    public float distanceMax ;
    public float distanceMin ;

    public GameObject[] thePlatforms;
    int platformSelector;
    float[] platformWidths;

    float minHi;
    float maxHi;
    public Transform maxHiPoint;
    float hiChange;

    void Start()
    {
        platformWidths = new float[thePlatforms.Length];
        for (int i = 0; i < thePlatforms.Length; i++)
        {
            platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x;
       
        }

        minHi = transform.position.y;
        maxHi = maxHiPoint.position.y;
        //  minHi = -2f;
        // maxHi = 1f;


    }

    void Update()
    {
       
        if (transform.position.x <= point.position.x)
        {
            platformSelector = Random.Range(0, thePlatforms.Length);
            float platformWidth = platformWidths[platformSelector];
            float distanceBetween = Random.Range(distanceMin, distanceMax - (platformWidth/3)); // Adjust the distance range

            hiChange = Random.Range(minHi, maxHi);
            if (hiChange > maxHi)
            {
                hiChange = maxHi;
            }
            else if (hiChange < minHi)
            {
                hiChange = minHi;
            }


            // Move the transform by the distance between plus the width of the selected platform
            float newXPosition = transform.position.x + distanceBetween + ((platformWidth / 3));
            Debug.Log("New X position: " + newXPosition);
            transform.position = new Vector3(newXPosition, hiChange, transform.position.z);

            Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);
        }
    }
}