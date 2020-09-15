using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {
    public Text score;
    public int totalScore = 0;

    void OnCollisionEnter (Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Coin") {
            totalScore++;
        }
    }

    void Update () {
        score.text = totalScore.ToString ();
    }
}