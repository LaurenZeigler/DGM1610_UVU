using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    private GameManager gm;
    private Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rend = GameObject.Find("FlagHome").GetComponent<Renderer>();
        rend.enabled = false; //Hide the Flag
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && gm.hasFlag)
        {
            Debug.Log("Player has reached home base with the flag!");
            gm.PlaceFlag(); // Run placeflag from < GameManager > script
            rend.enabled = true; // Make the flag visable to player
        }
    }
}
