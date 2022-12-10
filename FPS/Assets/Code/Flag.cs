using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private GameManager gm;
    private Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find and reference gamemanager
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) //added if statement w tylers
        {
            gm.hasFlag = true; // Get the flag and set bool to true
            rend.enabled = false; // Hide flag when held
        }
    }
}
