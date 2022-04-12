
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    int currentSceneIndex;
    void OnCollisionEnter(Collision other) {
            switch (other.gameObject.tag) {
                case "Friendly":
                    Debug.Log("Hello Friend!");
                    break;
                case "Finish":
                    LoadNextLevel();
                    break;
                default:
                    Debug.Log("You died :(");
                     ReloadLevel();
                    break;
            }
    }

    void ReloadLevel() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel() {
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
