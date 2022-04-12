
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
                    Debug.Log("YAAAYYY. YOU MADE IT!");
                    break;
                default:
                    Debug.Log("You died :(");
                     ReloadLevel();
                    break;
            }
    }

    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
