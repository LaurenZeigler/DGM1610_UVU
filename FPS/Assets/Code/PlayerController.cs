using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    [Header("Player Movement")]
    public float moveSpeed;
    public float jumpForce;
    // Looking around
    [Header("Camera")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotX;
    // Connect to camera
    private Camera camera;
    private Rigidbody rb; //Rigidbody

    // Awake is before the start function
    void Awake()
    {
        // Get component
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraLook();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity; // Up and Down
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity; // Left and Right
    }

    void Jump()
    {

    }
}
