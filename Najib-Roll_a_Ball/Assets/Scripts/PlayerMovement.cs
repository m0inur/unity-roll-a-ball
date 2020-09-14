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
    bool isUp = false;
    bool canJump = true;

    // Movement Speed
    public int speedX = 20;
    public int speedY = 30;
    public int speedZ = 20;
    Vector3 stop = new Vector3 (0, 0, 0);

    // Give variables value
    void Start () {
        rb = GetComponent<Rigidbody> ();
        // rb.useGravity = false;
        // stop = new Vector3 (0, 0, 0);
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

        if (Input.GetKey ("space")) {
            Debug.Log ("Space pressed");
            if (canJump) {
                Debug.Log ("Can jump");
                isUp = true;
            }
        }
    }

    // Add physics on players input
    void FixedUpdate () {
        // rb.AddForce (0, gravity * Time.deltaTime, 0, ForceMode.VelocityChange);
        if (!isStraight && !isLeft && !isRight && !isBackwards) {
            // rb.velocity = stop;
            isStraight = false;
        }

        /* Jump mechanics */
        if (transform.position.y <= 0) {
            canJump = false;
        }

        if (transform.position.y >= 2.5) {
            canJump = false;
            isUp = false;
        }

        if (transform.position.y <= 1) {
            canJump = true;
            isUp = false;
        }

        if (isUp) {
            rb.AddForce (0, speedY * Time.deltaTime, 0, ForceMode.VelocityChange);
            Debug.Log ("Adding force to jump");
            canJump = false;
        }
        /* Jump mechanics */

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