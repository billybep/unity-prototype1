using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    public List<WheelCollider> allWheels;

    // Private variables
    [SerializeField] private float speed;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 25.0f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float rpm;

    
    // Public variables
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    // FixedUpdate ==> Call before update call
    // Special usefull try to to movement or physic
    void FixedUpdate() 
    {
        // Player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); // for KPH
        speedometerText.SetText("Speed: " + speed + "mph");

        rpm = (speed % 30) * 40;
        rpmText.SetText("RPM: " + rpm);

        // Move player/vehicle based on vertical input
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
