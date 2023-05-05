using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hInput;
    public float speed; 
    public float xRange = 11.0f; //restrict movement later line28

    //blaster location and lazers
    public GameObject lazerBolt; //game object projectile to shoot
    public Transform blaster; // Point of origin for lazerbolt

    private AudioSource blasterAudio;
    public AudioClip laserBlast;

    // Start is called before the first frame update
    void Start()
    {
        blasterAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Obtain horizontal input from input manager Input.GetAxis. 
        hInput = Input.GetAxis("Horizontal") ;

        //translate.Transform gives value to movement in unity
        //when setting movement, Time.deltaTime is universal timing regardless of machine
        transform.Translate(Vector3.right * hInput * speed * Time.deltaTime);

        //keep player in bounds
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            blasterAudio.PlayOneShot(laserBlast, 1.0f);
            Instantiate(lazerBolt, blaster.transform.position, lazerBolt.transform.rotation); //instantiate lazerbolt in orientation and away from object
        }
    }
}
