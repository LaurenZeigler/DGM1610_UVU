using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class floatUp : MonoBehaviour
{

    public float moveSpeed;
    public float upperBound;
    private Balloon balloon;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        balloon = GetComponent<Balloon>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //move balloon upward
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        //destroy balloon when too far
        if (transform.position.y > upperBound)
        {
            scoreManager.DecreaseScoreText(balloon.scoreToGive);
            Destroy(gameObject);
            /*my own notes
             * 
             * to make animation for balloon
             * 
             * private Balloon <object> 
             * 
             * after destroy,
             *  create new object, which plays one set of particles
             *  destroy after 3 seconds
             * 
             */
        }
    }
}
