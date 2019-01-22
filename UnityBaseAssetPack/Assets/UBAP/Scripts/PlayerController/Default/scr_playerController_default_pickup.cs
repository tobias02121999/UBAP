using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerController_default_pickup : MonoBehaviour
{
    // Initialize the public variables
    public bool holdPositionIsAbsolute;
    public Transform holdPositionTransform;

    // Initialize the private variables
    scr_playerController_default_stats scriptStats;

    // Run this code once at the start (private)
    void Start()
    {
        // Connect the script component to the script variable
        scriptStats = GetComponent<scr_playerController_default_stats>();
    }

    // Run this code every single frame (private)
    void Update()
    {
        // 
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (scriptStats.canPickup)
            {
                if (scriptStats.pickupIsInRange)
                {
                    Pickup();
                    scriptStats.canPickup = false;
                }
            }
            else
            {
                DropPickup();
                scriptStats.canPickup = true;
            }
        }

        if (scriptStats.canPickup)
        {
            scriptStats.pickupParentOld = scriptStats.pickup.transform.parent;
        }
    }

    // Pick the pickupTarget object up (private)
    void Pickup()
    {
        scriptStats.pickup = scriptStats.pickupTarget;
        scriptStats.pickup.GetComponent<Rigidbody>().isKinematic = true;
        scriptStats.pickup.GetComponent<BoxCollider>().enabled = false;
        scriptStats.pickup.transform.parent = holdPositionTransform;

        if (holdPositionIsAbsolute)
            scriptStats.pickup.transform.position = holdPositionTransform.position;
    }

    // Drop the pickupTarget object (private)
    void DropPickup()
    {
        scriptStats.pickup.GetComponent<Rigidbody>().isKinematic = false;
        scriptStats.pickup.GetComponent<BoxCollider>().enabled = true;
        scriptStats.pickup.transform.parent = scriptStats.pickupParentOld;
    }
}
