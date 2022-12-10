using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int scoreToGive;

    public ParticleSystem explosionParticle;

    private AudioSource blasterAudio;
    public AudioClip laserBlast;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); //reference within scene the gameobject "ScoreManager"
    }

     // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        explosionParticle.Play();
        // explosionParticle.Stop();
        
        scoreManager.IncreaseScore(scoreToGive); // Increase Score
        Destroy(other.gameObject); //destroy other game object it hits 
        Destroy(gameObject); //destroy this object
    }
    void Explosion()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
        explosionParticle.transform.parent = null;
        blasterAudio.PlayOneShot(laserBlast, 1.0f);
    }
}
