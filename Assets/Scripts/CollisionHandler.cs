
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem explosionParticle;

    AudioSource rocketSound;
    bool isTransitioning = false;
    void Start() {
        rocketSound = GetComponent<AudioSource>();    
    }


    void Update() {
        // update method that calls on methods to skip level    
        SkipLevel();
        // method that disables collision
        DisableCollision();
    }

    void SkipLevel() {
        // if the "L" button is pressed then invoke next level method
        if (Input.GetKey(KeyCode.L)) {
            Invoke("LoadNextLevel", delayTime);
        }
    }

    void OnCollisionEnter(Collision other) {
        
        if (isTransitioning) return;

        switch (other.gameObject.tag) {
            case "Friendly":
                Debug.Log("Hello Friend!");
                break;
            case "Finish":
                Debug.Log("You made it to the next level!" + SceneManager.sceneCountInBuildSettings);
                StartFinishSequence();
                break;
            default:
                Debug.Log("You died :(");
                StartCrashSequence();
                break;
        }
    }

    void StartFinishSequence() {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        rocketSound.Stop();
        rocketSound.PlayOneShot(successSound);
        successParticle.Play();
        Invoke("LoadNextLevel", delayTime);
    }
    void StartCrashSequence() {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        rocketSound.Stop();
        explosionParticle.Play();
        rocketSound.PlayOneShot(deathSound);
        Invoke("ReloadLevel", delayTime);
    }

    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
