using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerController_default_feetCollider : MonoBehaviour
{
    // Initialize the private variables
    public scr_playerController_default_stats scriptStats;

    // Run this code once a valid collider enters the trigger (private)
    void OnTriggerStay(Collider other)
    {
        scriptStats.isGrounded = true; // Tell the player that its feet are currently colliding with the ground
    }

    // Run this code once a valid collider exits the trigger (private)
    void OnTriggerExit(Collider other)
    {
        scriptStats.isGrounded = false; // Tell the player that its feet are currently not colliding with the ground
    }
}
