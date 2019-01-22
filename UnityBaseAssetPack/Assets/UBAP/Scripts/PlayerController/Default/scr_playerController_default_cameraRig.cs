using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerController_default_cameraRig : MonoBehaviour
{
    // Initialize the public variables
    [HideInInspector]
    public bool isActive = true;

    public Camera[] playerCamera;
    public int playerCameraID;

    public Transform playerControllerTransform;
    public Transform cameraRigTransform;

    public string inputAxisX = "Mouse X";
    public string inputAxisY = "Mouse Y";

    public float inputClampY = 85f;

    public float lookSensitivityX = 5f;
    public float lookSensitivityY = 3.5f;

    public bool autoCameraSmoothing = true;
    public float cameraSmoothingX;
    public float cameraSmoothingY;

    // Initialize the private variables
    float rotationX;
    float rotationY;

    // Run this code every single frame (private)
    void Update()
    {
        // Run the script functions if it is currently set to active
        if (isActive)
        {
            // Rotate the playerController and cameraRig based on the user input
            CameraLook();

            // Enable the correct camera based on the cameraMode
            CameraSetMode();

            // Automatically set the 'best' camera smoothing values
            if (autoCameraSmoothing)
                SetCameraSmoothing();
        }
    }

    // Rotate the playerController and cameraRig based on the user input (private)
    void CameraLook()
    {
        // Add the Mouse Axis input to the rotational variables
        rotationX = Mathf.Clamp(rotationX - Input.GetAxis(inputAxisY) * lookSensitivityY, -inputClampY, inputClampY);
        rotationY += Input.GetAxis(inputAxisX) * lookSensitivityX;

        // Set the target Quaternion for both the cameraRig and playerController Transforms
        var cameraRigQuaternionTarget = Quaternion.Euler(rotationX, cameraRigTransform.eulerAngles.y, cameraRigTransform.eulerAngles.z);
        var playerControllerQuaternionTarget = Quaternion.Euler(playerControllerTransform.eulerAngles.x, rotationY, playerControllerTransform.eulerAngles.z);

        // Apply the rotational variables to the cameraRig and the playerController Transforms
        cameraRigTransform.rotation = Quaternion.Slerp(cameraRigTransform.rotation, cameraRigQuaternionTarget, cameraSmoothingX);
        playerControllerTransform.rotation = Quaternion.Slerp(playerControllerTransform.rotation, playerControllerQuaternionTarget, cameraSmoothingY);
    }

    // Enable the correct camera based on the cameraMode (private)
    void CameraSetMode()
    {
        // Enable / disable the cameras stored in the playerCamera variable based on the given playerCameraID
        for (int i = 0; i < playerCamera.Length; i++)
        {
            if (i == playerCameraID)
                playerCamera[i].enabled = true;
            else
                playerCamera[i].enabled = false;
        }
    }

    // Automatically set the 'best' camera smoothing values (private)
    void SetCameraSmoothing()
    {
        // The higher the mouse sensitivity, the higher the smoothing
        cameraSmoothingX = Mathf.Clamp(lookSensitivityX / 10f, .1f, 1f);
        cameraSmoothingY = Mathf.Clamp(lookSensitivityY / 10f, .1f, 1f);
    }
}
