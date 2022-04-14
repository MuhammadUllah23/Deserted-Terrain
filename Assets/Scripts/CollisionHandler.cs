
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision other) {
            switch (other.gameObject.tag) {
                case "Friendly":
                    Debug.Log("Hello Friend!");
                    break;
                case "Finish":
                    Debug.Log("You made it to the next level!" + SceneManager.sceneCountInBuildSettings);
                    LoadNextLevel();
                    break;
                default:
                    Debug.Log("You died :(");
                    StartCrashSequence();
                    break;
            }
    }

    void StartCrashSequence() {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);
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
