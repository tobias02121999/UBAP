using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerController_default_stats : MonoBehaviour
{
    // Initialize the public variables
    [HideInInspector]
    public bool isGrounded;

    [HideInInspector]
    public bool pickupIsInRange;

    [HideInInspector]
    public bool canPickup = true;

    [HideInInspector]
    public GameObject pickupTarget;

    [HideInInspector]
    public GameObject pickup;

    [HideInInspector]
    public Transform pickupParentOld;
}
