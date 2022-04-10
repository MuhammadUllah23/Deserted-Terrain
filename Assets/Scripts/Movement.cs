using System.Collections;
using System.Collections.Generic;

// UnityEngine is the namespace that all of the MonoBehaviour content lives within
using UnityEngine;

// Our movement class is inheritting content created in MonoBehaviour 
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }

    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            Debug.Log("Pressed Space - Thrusting");
        }
       
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("Rotate Right");
        }
        else if (Input.GetKey(KeyCode.A)) {
            Debug.Log("Rotate Left");
        }
        
    }
}
