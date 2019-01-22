using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerController_default_stateMachine : MonoBehaviour
{
    // Initialize the playerState enumerator
    public enum playerStates {Default, Frozen};

    // Initialize the public variables
    [HideInInspector]
    public playerStates playerState;

    // Initialize the private variables
    scr_playerController_default_movement scriptMovement;
    scr_playerController_default_cameraRig scriptCameraRig;
    scr_playerController_default_jumping scriptJumping;

    // Run this code once at the start (private)
    void Start()
    {
        // Connect the script components to the script variables
        GetScriptComponents();
    }

    // Run this code every single frame (private)
    void Update()
    {
        // Run the player functions according to the current playerState
        RunPlayerState();
    }

    // Run the player functions according to the current playerState (private)
    void RunPlayerState()
    {
        // Switch through the different playerStates and run the corresponding code
        switch (playerState)
        {
            // The Default playerState
            case playerStates.Default:
                // Enable / disable the script components to match the current state
                scriptMovement.isActive = true;
                scriptCameraRig.isActive = true;
                scriptJumping.isActive = true;
                break;

            // The Frozen playerState
            case playerStates.Frozen:
                // Enable / disable the script components to match the current state
                scriptMovement.isActive = false;
                scriptCameraRig.isActive = true;
                scriptJumping.isActive = false;
                break;
        }
    }

    // Connect the script components to the script variables (private)
    void GetScriptComponents()
    {
        // Get the script components from this object and store them in the script variables
        scriptMovement = GetComponent<scr_playerController_default_movement>();
        scriptCameraRig = GetComponent<scr_playerController_default_cameraRig>();
        scriptJumping = GetComponent<scr_playerController_default_jumping>();
    }

    // Switch to a given targetState for a specific amount of time, then switch back to a given returnState (public)
    public IEnumerator SwitchStateCycle(playerStates targetState, playerStates returnState, float duration)
    {
        playerState = targetState; // Set the playerState to the given targetState
        yield return new WaitForSeconds(duration); // Wait for a specific amount of time
        playerState = returnState; // Switch the playerState back to a given returnState
    }
}
