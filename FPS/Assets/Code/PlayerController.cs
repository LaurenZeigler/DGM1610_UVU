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
        float x = Input.GetAxis("Horizontal") * moveSpeed; // Input for left and right movement
        float z = Input.GetAxis("Vertical") * moveSpeed; // Input for forward and back movement

        // Vector3 dir = (transform.right * x) + (transform.forward * z);
        // dir.y = rb.velocity.y;
        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity; // Up and Down
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity; // Left and Right

        // Drives camera rotation
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
