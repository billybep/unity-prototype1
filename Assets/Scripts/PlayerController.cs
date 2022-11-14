using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private variables
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float turnSpeed = 25.0f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    // Public variables
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    // Update is called once per frame
    // FixedUpdate ==> Call before update call
    // Special usefull try to to movement or physic
    void FixedUpdate() 
    {
        // Player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move player/vehicle based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
