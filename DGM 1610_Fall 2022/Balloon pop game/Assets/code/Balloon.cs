using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Balloon : MonoBehaviour
{

    public int clickToPop = 3; // pop after 3 clicks

    public float scaleToIncrease = 0.10f; // Inflate when clicked by 10%
    public int scoreToGive = 100;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        //reference scoremanager component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnMouseDown()
    {
        clickToPop -= 1; //reduces clicks to pop by 1

        //inflate balloon 10% once clicked
        transform.localScale += Vector3.one * scaleToIncrease;

        //click to see if clickToPop has reached zero. If it has, then destroy.
        if(clickToPop == 0)
        {
            // send points to Score Manager, and update
            scoreManager.IncreaseScoreText(scoreToGive);
            Destroy(gameObject);
        }
    }
}
