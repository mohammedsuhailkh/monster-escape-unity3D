using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFolllow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    private float minX = -85, maxX = 85;
    private Vector3 offset;
    
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position; // Calculate the initial offset
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;

        tempPos = player.position + offset; // Calculate the new position with the offset

        // Ensure that the camera stays within the boundaries
        tempPos.x = Mathf.Clamp(tempPos.x, minX, maxX);

        transform.position = tempPos;
    }
}
