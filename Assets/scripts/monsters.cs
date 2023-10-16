using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsters : MonoBehaviour
{
    [SerializeField] public float speed; // Adjust the speed as needed
    private Rigidbody myBody;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        myBody.velocity = new Vector3(speed, myBody.velocity.y, myBody.velocity.x);
    }
}
