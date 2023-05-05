using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOOB : MonoBehaviour
{

    public float topBounds = 30.0f;
    public float lowerBounds = -10.0f;
    public ScoreManager scoreManager;
    public int scoreToGive;

    // Start is called before the first frame update
    void Start()
    {
       scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        // DetectCollision = GetComponent<DetectCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBounds)
        {
            scoreManager.DecreaseScore(scoreToGive);
            Destroy(gameObject);
        }

        else if(transform.position.z < lowerBounds)
        {
            Destroy(gameObject);
        }
    }
}
