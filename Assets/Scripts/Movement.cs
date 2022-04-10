using System.Collections;
using System.Collections.Generic;

// UnityEngine is the namespace that all of the MonoBehaviour content lives within
using UnityEngine;

// Our movement class is inheritting content created in MonoBehaviour 
public class Movement : MonoBehaviour
{
    Rigidbody objectRigidbody;
    [SerializeField] float mainThrust = 100f;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
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
            objectRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            // Same Outcome: objectRigidbody.AddRelativeForce(0, 1, 0);
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
