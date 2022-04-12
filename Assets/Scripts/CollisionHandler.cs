
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
            switch (other.gameObject.tag) {
                case "Friendly":
                    Debug.Log("Hello Friend!")
                    break;
            }
    }
}
