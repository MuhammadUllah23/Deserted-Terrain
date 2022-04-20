using System.Collections;
using System.Collections.Generic;

// UnityEngine is the namespace that all of the MonoBehaviour content lives within
using UnityEngine;

// Our movement class is inheritting content created in MonoBehaviour 
public class Movement : MonoBehaviour
{

    // PARAMETERS - for tuning, typically set in the editor
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateThrust = 500f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem leftBoosterParticle;
    [SerializeField] ParticleSystem rightBoosterParticle;
    [SerializeField] ParticleSystem mainThrustParticle;
    
    // CACHE - e.g. references for readability or speed
    Rigidbody objectRigidbody;
    AudioSource rocketSound;
    // STATE - private instance (member) variables
    
    
   

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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

  void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();

        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else
        {
            StopPlayingParticles();
        }

    }
    
    void StartThrusting()
    {
        objectRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        // Same Outcome: objectRigidbody.AddRelativeForce(0, 1, 0);

        if (!rocketSound.isPlaying)
        {
            rocketSound.PlayOneShot(mainEngine);

        }
        if (!mainThrustParticle.isPlaying)
        {
            mainThrustParticle.Play();
        }
    }
    void StopThrusting()
    {
        rocketSound.Stop();
        mainThrustParticle.Stop();
    }

    void RotateRight()
    {
        ApplyRotation(rotateThrust);
        if (!leftBoosterParticle.isPlaying)
        {
            leftBoosterParticle.Play();
        }
    }

    void RotateLeft()
    {
        ApplyRotation(-rotateThrust);
        if (!rightBoosterParticle.isPlaying)
        {
            rightBoosterParticle.Play();
        }
    }

    void StopPlayingParticles()
    {
        rightBoosterParticle.Stop();
        leftBoosterParticle.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        objectRigidbody.freezeRotation = true; // freezing rotation so we can manually rotate.
        transform.Rotate(-Vector3.forward * rotationThisFrame * Time.deltaTime);
        // objectRigidbody.freezeRotation = false; // unfreezing rotation so the physics system can take over.
        objectRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
    }
}
