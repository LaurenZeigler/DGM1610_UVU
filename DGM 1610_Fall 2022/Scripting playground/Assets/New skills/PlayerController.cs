using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.00f;
    public float rotSpeed = 50.00f;

    Rigidbody playerRb;

    float hInput;
    float vInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get keyboard inputs 
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // Move the player character forward and backward
        // Time.deltaTime helps computers run at the same speed.
        transform.Translate(Vector3.forward * vInput * speed * Time.deltaTime);
        // Rotate the player character left and right
        transform.Rotate(Vector3.up, hInput * rotSpeed * Time.deltaTime);
    }
}
