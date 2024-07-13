using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRemover : MonoBehaviour
{
    public GameObject platformRemoverPoint;
    // Start is called before the first frame update
    void Start()
    {
        platformRemoverPoint = GameObject.Find("PlattformRemovePoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < platformRemoverPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
