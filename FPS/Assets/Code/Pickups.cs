using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public PickupType type;
    public int healthAmount;
    public int ammoAmount;

    //public int value;

    [Header("Bobbing motion")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool bobbingUp;
    private Vector3 startPos;

    public AudioClip pickupSFX;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    public enum PickupType
    {
        Health,
        Ammo
    }

    void onTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            switch(type)
            {
                case PickupType.Health:
                    player.GiveHealth(healthAmount);
                    break;

                case PickupType.Ammo:
                    player.GiveAmmo(ammoAmount);
                    break;

                default:
                    print("Type not accepted");
                    break;
            }
            //Reference Audio Source to play sound effect
            //other.GetComponent<AudioSource>.PlayOneShot(pickupSFX);

            // Destroy Pickup
             Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Rotates pickup around y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime); // Spin in another direction
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime); // SPIN BANABA SPIN CAN YOU FEEL IT YES FEEL THE SPEED  GO Go oO

        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight / 2, 0));

        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if (transform.position == startPos + offset)
            bobbingUp = !bobbingUp;
    }
}
