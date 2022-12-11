using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variables : MonoBehaviour
{
    public float health = 2.5f;
    private double hitpoints = 15.12f;
    private int candies;
    public float amountOfMoney;
    public string name = "Veronica";
    private char grade = 'F';
    bool failing;
    
    void Start()
    {
        if(grade == 'F')
        {
            failing = true
            Debug.Log("Failing")
        }
    }

}
