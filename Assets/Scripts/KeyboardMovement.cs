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
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        // Code from labs

        // Can use Vector3.up or transform.up
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
            inputVector.z *= sprintSpeedMultiplier;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpForce * 10 * Vector3.up, ForceMode.Acceleration);
        }

        // Crouch - my addition
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if (tr.localScale == playerScale) 
                tr.localScale = new Vector3(0.5f, 0.25f, 0.5f);
            else 
                tr.localScale = playerScale;
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
