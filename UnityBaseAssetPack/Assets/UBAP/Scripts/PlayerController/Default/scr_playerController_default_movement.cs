using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerController_default_movement : MonoBehaviour
{
    // Initialize the public variables
    [HideInInspector]
    public bool isActive = true;

    public string inputAxisX = "Horizontal";
    public string inputAxisY = "Vertical";

    public float movementSpeedForward = 5f;
    public float movementSpeedBackward = 4f;
    public float movementSpeedLeft = 4.5f;
    public float movementSpeedRight = 4.5f;

    // Initialize the private variables
    private float movementSpeedX;
    private float movementSpeedY;

    // Initialize the private variables
    Rigidbody playerControllerRigidbody;

    // Run this code once at the start (private)
    void Start()
    {
        // Connect the script component to the script variable
        playerControllerRigidbody = GetComponentInParent<Rigidbody>();
    }

    // Run this code every single fixed frame (private)
    void FixedUpdate()
    {
        // Run the script functions if it is currently set to active
        if (isActive)
        {
            // Get the user input
            GetInput();

            // Move the player around based on the user input
            Move();
        }
    }

    // Get the user input (private)
    void GetInput()
    {
        // Set the movementSpeed based on the user input and movementSpeed variables (forward & backward)
        if (Input.GetAxis(inputAxisY) > 0f)
            movementSpeedY = Input.GetAxis(inputAxisY) * movementSpeedForward;
        if (Input.GetAxis(inputAxisY) < 0f)
            movementSpeedY = Input.GetAxis(inputAxisY) * movementSpeedBackward;

        // Set the movementSpeed based on the user input and movementSpeed variables (left & right)
        if (Input.GetAxis(inputAxisX) > 0f)
            movementSpeedX = Input.GetAxis(inputAxisX) * movementSpeedRight;
        if (Input.GetAxis(inputAxisX) < 0f)
            movementSpeedX = Input.GetAxis(inputAxisX) * movementSpeedLeft;

        // Reset the movementSpeed variables back to 0 if no input is given by the user
        if (Input.GetAxis(inputAxisY) == 0f)
            movementSpeedY = 0f;

        if (Input.GetAxis(inputAxisX) == 0f)
            movementSpeedX = 0f;
    }

    // Move the player around based on the user input (private)
    void Move()
    {
        // Set the playerVelocity based on the movementSpeed variables (calculated in the getInput function)
        var playerVelocity = (transform.forward * movementSpeedY) + (transform.right * movementSpeedX);
        playerVelocity.y = playerControllerRigidbody.velocity.y; // This makes sure that gravity is still applied as it normally would
        playerControllerRigidbody.velocity = playerVelocity;
    }
}
