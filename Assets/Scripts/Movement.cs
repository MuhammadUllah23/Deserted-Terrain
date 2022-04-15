using System.Collections;
using System.Collections.Generic;

// UnityEngine is the namespace that all of the MonoBehaviour content lives within
using UnityEngine;

// Our movement class is inheritting content created in MonoBehaviour 
public class Movement : MonoBehaviour
{
    Rigidbody objectRigidbody;
    AudioSource rocketSound;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateThrust = 500f;
    [SerializeField] AudioClip mainEngine;
   

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
        
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

            if(!rocketSound.isPlaying) {
                rocketSound.PlayOneShot(mainEngine);
            } 
        } else {
            rocketSound.Stop();
        }
       
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotateThrust);
        }
        else if (Input.GetKey(KeyCode.A)) {
            ApplyRotation(-rotateThrust);
        }
        
    }

    void ApplyRotation(float rotationThisFrame)
    {
        objectRigidbody.freezeRotation = true; // freezing rotation so we can manually rotate.
        transform.Rotate(-Vector3.forward * rotationThisFrame * Time.deltaTime);
        // objectRigidbody.freezeRotation = false; // unfreezing rotation so the physics system can take over.
        objectRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
    }
}
