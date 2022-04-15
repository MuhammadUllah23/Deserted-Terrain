
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip successSound;

    AudioSource rocketSound;
    void Start() {
        rocketSound = GetComponent<AudioSource>();    
    }

    void OnCollisionEnter(Collision other) {
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
        GetComponent<Movement>().enabled = false;
        rocketSound.PlayOneShot(successSound);
        Invoke("LoadNextLevel", delayTime);
    }
    void StartCrashSequence() {
        GetComponent<Movement>().enabled = false;
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
