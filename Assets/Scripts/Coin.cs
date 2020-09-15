using UnityEngine;

public class Coin : MonoBehaviour {
    float speed = 2f;

    void OnCollisionEnter (Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Player") {
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Rotate (0, speed, 0);
    }
}