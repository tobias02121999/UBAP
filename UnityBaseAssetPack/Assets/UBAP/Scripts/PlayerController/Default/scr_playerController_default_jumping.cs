using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerController_default_jumping : MonoBehaviour
{
    // Initialize the public variables
    [HideInInspector]
    public bool isActive = true;

    public float jumpForce = 5f;

    // Initialize the private variables
    Rigidbody playerControllerRigidbody;

    // Initialize the private variables
    scr_playerController_default_stats scriptStats;

    // Run this code once at the start (private)
    void Start()
    {
        // Connect the script components to the script variables
        GetScriptComponents();
    }

    // Run this code every single fixed frame (private)
    void FixedUpdate()
    {
        // Run the script functions if it is currently set to active
        if (isActive)
        {
            // Make the player jump according to the given jumpForce
            if (Input.GetKeyDown("space") && scriptStats.isGrounded)
                jump();
        }
    }

    // Make the player jump according to the given jumpForce (private)
    void jump()
    {
        // Set an upward velocity based on the given jumpForce to make the player jump
        playerControllerRigidbody.velocity = transform.up * jumpForce;
    }

    // Connect the script components to the script variables (private)
    void GetScriptComponents()
    {
        // Get the script components from this object and store them in the script variables
        scriptStats = GetComponent<scr_playerController_default_stats>();
        playerControllerRigidbody = GetComponentInParent<Rigidbody>();
    }
}
