using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    int totalScore = 0;

    void OnCollisionEnter (Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Coin") {
            Destroy (gameObject);
            totalScore++;
            Debug.Log (totalScore);
        }
    }

}