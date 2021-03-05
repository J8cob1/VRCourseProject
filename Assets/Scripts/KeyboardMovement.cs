using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform tr;
    private Vector3 playerScale;
    public float moveSpeed = 35f;
    public float sprintSpeedMultiplier = 1.6f;
    public float jumpForce = 35f;

    private Vector3 inputVector;
    private bool isGrounded = true;

    void Start()
    {
        // Gets the height of the transform
        playerScale = tr.localScale; 
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entered");
        print(collision.gameObject);
        if (collision.gameObject.CompareTag("Terrain"))
        {
            print("collided with terrain");
            this.isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        //Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Terrain"))
        {
            print("stopped colliding with terrain");
            this.isGrounded = false;
        }
    }

    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
            inputVector.z *= sprintSpeedMultiplier;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            print(isGrounded);
            rb.AddForce(jumpForce * 10 * Vector3.up, ForceMode.Acceleration);
        }

        // Crouch
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if (tr.localScale == playerScale) 
                tr.localScale = new Vector3(0.2f, 0.08f, 0.2f);
            else 
                tr.localScale = playerScale;
        }

        // Keep the player within the bounds of the map by bouncing them back in if they ever try to go out
        Vector3 playerPosition = tr.position;
        if (playerPosition.y < 0) {
            tr.position = new Vector3(playerPosition.x, playerPosition.y + 1.6f, playerPosition.z);
        }
        if (playerPosition.x < -50) {
            tr.position = new Vector3(playerPosition.x + .1f, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.x > 50) {
            tr.position = new Vector3(playerPosition.x - .1f, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.z < -50) {
            tr.position = new Vector3(playerPosition.x + .1f, playerPosition.y, playerPosition.z + 1);
        }
        if (playerPosition.z > 50) {
            tr.position = new Vector3(playerPosition.x - .1f, playerPosition.y, playerPosition.z - 1);
        }
    }

    // Runs a set number of times per second (default, it's 30)
    void FixedUpdate()
    {
        Vector3 movement = moveSpeed * 10f * inputVector.z * Time.fixedDeltaTime * transform.forward +
                            moveSpeed * 10f * inputVector.x * Time.fixedDeltaTime * transform.right;

        rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);
    }

}
