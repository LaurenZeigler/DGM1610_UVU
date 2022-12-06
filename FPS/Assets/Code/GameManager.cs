using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Flag Stats")]
    public bool hasFlag;
    public bool flagPlaced;

    public int scoreToWin;
    public int curScore;

    public bool gamePaused;

    // instance
    public static GameManager instance;

    void Awake()
    {
        // Set instance to this script
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Flag bools
        hasFlag = false;
        flagPlaced = false;

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (flagPlaced)
        {

        }

        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //Toggle the pause menu with the curser
        GameUI.instance.TogglePauseMenu(gamePaused);
        Curser.lockState = gamePaused == true ? CursorLockMode.None : CurserLockMode.Locked;

    }

    public void PlaceFlag()
    {
        flagPlaced = true;
    }

}
