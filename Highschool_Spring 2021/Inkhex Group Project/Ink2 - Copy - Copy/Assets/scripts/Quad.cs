using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour

{
    public float speed = .02f;

    ControllerScript controller;

    float xPos = 0;

    public string sortingLayer = "Background";
    // Start is called before the first frame update
    void Start()
    {
        // put this quad in the target sorting layer
        Renderer r = GetComponent<Renderer>();
       

        // get and store reference to ControllerScript for future use
        GameObject controllerObj = GameObject.Find("Controller");
        controller = controllerObj.GetComponent<ControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        xPos += Time.deltaTime * speed;

        // keep offset in the 0.0 to 1.0 range
        if (xPos >= 1.0f)
        {
            xPos = 0.0f;
        }

        // build vector of new offset
        Vector2 offset = new Vector2(xPos, 0);

        // update the mainTextureOffset
        Renderer r = GetComponent<Renderer>();
        r.material.mainTextureOffset = offset;



    }
}
