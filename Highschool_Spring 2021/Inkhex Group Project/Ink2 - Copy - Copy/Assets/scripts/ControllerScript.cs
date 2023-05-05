using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
  
    public GameObject EnemyPrefab;
    public float maxEnemySpeed = 1.0f;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CreateEnemy()
    {
        GameObject Enemy = createPrefab(EnemyPrefab);
        float xSpeed = Random.value * -maxEnemySpeed;

        Rigidbody2D rb = Enemy.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xSpeed, 0);

    }
    GameObject createPrefab(GameObject prefab)
    {
        // calculate the height and width of the screen
        float worldHeight = Camera.main.orthographicSize * 2.0F;
        float worldWidth = worldHeight * Camera.main.aspect;

        // create new prefab and get Renderer
        GameObject newObj = Instantiate(prefab);
        Renderer objR = newObj.GetComponent<Renderer>();

        // *** student code to finish this function goes here
        // get world Y-coordinate of top of the platform
        GameObject platform = GameObject.Find("PlatformQuad");
        Renderer platformR = platform.GetComponent<Renderer>();
        float platformTopY = platformR.bounds.max.y;

        // calculate x position just off the side of the screen
        float x = (worldWidth / 2.0F) + objR.bounds.size.x;

        // Calculate random Y position between top of screen
        // and top of platform. 
        // Shrink the range by half the object's height so 
        // object will always be fully visible within that range.
        float maxY = (worldHeight / 2.0F) - (objR.bounds.size.y / 2.0f);
        float minY = platformTopY + (objR.bounds.size.y / 2.0f);

        // get new random Y position between minY and maxY
        float y = Random.Range(minY, maxY);

        // update new prefab's position
        newObj.transform.position = new Vector3(x, y, 0);

        // send back reference to calling function
        return newObj;
    }
    // Update is called once per frame
    void Update()
    {
        // get references to the platform layer
        GameObject platform = GameObject.Find("PlatformQuad");
        Renderer r = platform.GetComponent<Renderer>();

        // figure out change in X for the platform
        Quad platformScript = platform.GetComponent<Quad>();
        float xChange = r.bounds.size.x * Time.deltaTime * platformScript.speed;


        // update x position of all non-player objects in the game

        // find world coordinate of left edge of the screen
        float worldHeight = Camera.main.orthographicSize * 2.0F;
        float worldWidth = worldHeight * Camera.main.aspect;

        updateObjectPositions("Spell", xChange, -worldWidth / 2.0f);
        updateObjectPositions("Enemy", xChange, -worldWidth / 2.0f);

        

    }

    void updateObjectPositions(string tag, float xChange, float xLeftBoundary)
    {
        // get all objects with specified tag
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");

        // *** student code to finish this function goes here

        foreach (GameObject obj in objects)
        {

            obj.transform.Translate(-xChange, 0, 0);

            //Get the renderer component
            Renderer r = obj.GetComponent<Renderer>();

            //if object X position is less than the left boundary coordinate
            // minus the width of the object ( to ensure its fully off the screen)
            if (obj.transform.position.x < xLeftBoundary - r.bounds.size.x)
            {
                Destroy(obj);
            }
        }



    }
}
