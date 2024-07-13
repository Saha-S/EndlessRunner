using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController myPlayerController;
    Vector3 lastPosition;
    float distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerController = FindObjectOfType<PlayerController>();
        lastPosition= myPlayerController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = myPlayerController.transform.position.x - lastPosition.x;
        transform.position = new Vector3 (myPlayerController.transform.position.x, transform.position.y, transform.position.z);
        lastPosition = myPlayerController.transform.position;
    }
}
