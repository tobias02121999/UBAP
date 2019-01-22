using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerController_default_handsCollider : MonoBehaviour
{
    // Initialize the private variables
    public scr_playerController_default_stats scriptStats;

    // Run this code once a valid collider enters the trigger (private)
    void OnTriggerStay(Collider other)
    {
        scriptStats.pickupIsInRange = true; // Tell the player that its hands are currently colliding with a pickup object
        scriptStats.pickupTarget = other.gameObject; // Tell the player which pickup gameObject the hands are colliding with
    }

    // Run this code once a valid collider exits the trigger (private)
    void OnTriggerExit(Collider other)
    {
        scriptStats.pickupIsInRange = false; // Tell the player that its hands are currently not colliding with a pickup object
    }
}
