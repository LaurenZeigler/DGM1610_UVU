using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    Vector2 upperRightWorld;
    Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        float worldHeight = Camera.main.orthographicSize * 2.0F;
        float worldWidth = worldHeight * Camera.main.aspect;

        upperRightWorld = new Vector2(worldWidth / 2.0F, worldHeight / 2.0F);

        // Get the object's Renderer component for later use
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if object X position is greater than the right boundary coordinate
        // plus the width of the object (to ensure it's fully off the screen)
        if (transform.position.x > upperRightWorld.x + r.bounds.size.x)
        {
            Destroy(this.gameObject);  // destroy this object
        }
        
    }

     void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("Enemy"))
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);

            GameObject controller = GameObject.Find("Controller");
        }
    }

}

