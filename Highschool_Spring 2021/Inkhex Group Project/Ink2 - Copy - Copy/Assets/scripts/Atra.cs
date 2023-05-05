//Unity game programming
//Project InkHex
//Atheena Allred, Lauren Zeigler, Allison Sigmon, Ethan Benson
//



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atra : MonoBehaviour
{
    //EVERY PUBLIC CLASS
    PositionClamp spriteClamp;

    Rigidbody2D rb;

    public float AtraSpeed = .03f;

    public float jumpForce = 300.0f;
    int numJumps;

    public float SpellSpeed = 15.0f;
    public GameObject Spell1Prefab;

    // animation
    private Animator Aatra;


    // Start is called before the first frame update
    void Start()
    {
        //CAMERA AWESOMNESS, JUMPS AND CONTROLLER STUFF
        float worldHeight = Camera.main.orthographicSize * 2.0f;
        float worldWidth = worldHeight * Camera.main.aspect;

        float xMin = -worldWidth / 2.0f;
        float yMin = -worldHeight / 2.0f;
        float xMax = worldWidth / 2.0f;
        float yMax = worldHeight / 2.0f;

        rb = GetComponent<Rigidbody2D>();

        Renderer r = GetComponent<Renderer>();

        spriteClamp = new PositionClamp(xMin, yMin, xMax, yMax, r);

        numJumps = 1;

        GameObject controllerObj = GameObject.Find("Controller");

        //animation
        Aatra = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVEMENT, JUMPS, KEY BIND
        transform.Translate(Input.GetAxis("Horizontal") * AtraSpeed, 0, 0);


        Vector3 oldposition = transform.position;

        Vector3 newPosition = transform.position;

        if (numJumps > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(new Vector2(0, jumpForce));
                numJumps--;
            }
        }

        if (newPosition.y < oldposition.y)
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireShot();
        }


        // __ ANIMATION __
        // Flip direction
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        // Swap animation when moving
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Aatra.SetBool("walking", true);
        }
        else
        {
            Aatra.SetBool("walking", false);
        }

    }

    //JUMPING
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        // if we have hit the hidden pletform
        if (otherObject.gameObject.CompareTag("HiddenPlatform"))
        {
            // reset the available number of jumps each time
            // the player touches the platform
            numJumps = 1;
        }
    }
    //SPELLS
    void fireShot()
    {
        GameObject Spell1 = (GameObject)Instantiate(Spell1Prefab, transform.position, transform.rotation);
        Rigidbody2D rb = Spell1.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(SpellSpeed, 0);
        StartCoroutine(scheduleDestroy(1.0F, Spell1));
    }
    
    IEnumerator scheduleDestroy(float delay, GameObject target)
    {
        yield return new WaitForSeconds(delay);

        Destroy(target);
    }


    
}
