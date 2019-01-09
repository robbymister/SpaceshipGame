using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float difficultyMultiplier = 1.5f;

    public float minXspeed = 0.8f;
    public float maxXspeed = 1.2f;
    public float minYspeed = 0.8f;
    public float maxYspeed = 1.2f;
    private Rigidbody2D ballBody;
	// Use this for initialization
	void Start () {
        ballBody = GetComponent<Rigidbody2D>();
        ballBody.velocity = new Vector2(Random.Range(minXspeed,maxXspeed) * (Random.value > 0.5f ? -1 : 1), Random.Range(minYspeed, maxYspeed) * (Random.value > 0.5f ? -1:1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Limit")
        {
            GetComponent<AudioSource>().Play();
            if (other.transform.position.y > transform.position.y && ballBody.velocity.y > 0) // Top-limit
            {
                ballBody.velocity = new Vector2(ballBody.velocity.x, -ballBody.velocity.y);
            } if (other.transform.position.y < transform.position.y && ballBody.velocity.y < 0) // Bot limit
            {
                ballBody.velocity = new Vector2(ballBody.velocity.x, -ballBody.velocity.y);
            } 
        }
        else if (other.tag == "Paddle")
        {
            GetComponent<AudioSource>().Play();
            if (other.transform.position.x > transform.position.x && ballBody.velocity.x > 0) // Moving right
            {
                ballBody.velocity = new Vector2(-ballBody.velocity.x * difficultyMultiplier, ballBody.velocity.y * difficultyMultiplier);
            }
            if (other.transform.position.x < transform.position.x && ballBody.velocity.x < 0) // Moving left
            {
                ballBody.velocity = new Vector2(-ballBody.velocity.x * difficultyMultiplier, -ballBody.velocity.y * difficultyMultiplier);
            }
        }
    }
}
