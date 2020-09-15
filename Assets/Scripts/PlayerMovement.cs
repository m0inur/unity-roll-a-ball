using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Initialize Variables

    // Players RigidBody variable
    Rigidbody rb;

    // Movement Variables
    bool isStraight = false;
    bool isBackwards = false;
    bool isRight = false;
    bool isLeft = false;

    // Movement Speed
    public int speedX = 20;
    public int speedZ = 20;
    Vector3 stop = new Vector3 (0, 0, 0);

    // Give variables value
    void Start () {
        rb = GetComponent<Rigidbody> ();
    }

    // Catch player input
    void Update () {
        if (Input.GetKey ("w")) {
            isStraight = true;
        }

        if (Input.GetKey ("s")) {
            isBackwards = true;
        }

        if (Input.GetKey ("a")) {
            isLeft = true;
        }

        if (Input.GetKey ("d")) {
            isRight = true;
        }
    }

    // Add physics on players input
    void FixedUpdate () {
        if (isStraight) {
            rb.AddForce (0, 0, speedZ * Time.deltaTime, ForceMode.VelocityChange);
            isStraight = false;
        }

        if (isLeft) {
            rb.AddForce (-speedX * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            isLeft = false;
        }

        if (isRight) {
            rb.AddForce (speedX * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            isRight = false;
        }

        if (isBackwards) {
            rb.AddForce (0, 0, -speedZ * Time.deltaTime, ForceMode.VelocityChange);
            isBackwards = false;
        }
    }
}