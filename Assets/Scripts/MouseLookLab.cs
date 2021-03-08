using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look Lab")]
public class MouseLookLab : MonoBehaviour
{
    public enum RotationAxes {MouseXAndY = 0, MouseX = 1, MouseY = 2}
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public Camera playerCamera;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumY = -60F;
    public float maximumY = 60;

    private float rotationY = 0f;
    private bool zoomedIn = false;
    private float playerFieldOfView = 0;

    void Start()
    {
        // Locks the user's cursor into the game window
        Cursor.lockState = CursorLockMode.Locked;

        // Get the current field of view - I need this for zooming in and out
        playerFieldOfView = playerCamera.fieldOfView;
    }

    void Update()
    {
        // Code from labs
        if (axes == RotationAxes.MouseXAndY) {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            
            rotationY += Input.GetAxis("Mouse Y");
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX) 
        {
            transform.Rotate(0, Input.GetAxis("MouseX") * sensitivityX, 0);
        }
        else 
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        // Zoom in and out using the scrollwheel - my addition
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScroll != 0)
        {
            Vector3 cameraPos = playerCamera.transform.position;
            if (mouseScroll > 0 && !zoomedIn)
            {
                zoomedIn = true;
                playerCamera.fieldOfView  = playerFieldOfView / 2;
            }
            else if (mouseScroll < 0 && zoomedIn) 
            {
                zoomedIn = false;
                playerCamera.fieldOfView = playerFieldOfView;
            }
        }
    }
}


// Scripts are components


// Super Water Balloon Fight/Minecraft Clone