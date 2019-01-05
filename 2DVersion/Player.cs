using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float sizeOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        // Move the player.
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,0);
        } else if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 relativePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

                if (relativePosition.x < 0.5f)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        // Keep the player within bounds. Size offset should be pixel length of sprite and uses division by 100.
        float spriteSize = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float screenLimit = (Camera.main.orthographicSize * Camera.main.aspect) - spriteSize/2;
   
        if (transform.position.x > screenLimit)
        {
            transform.position = new Vector3(screenLimit, transform.position.y, transform.position.z);
        } else if (transform.position.x < -screenLimit)
        {
            transform.position = new Vector3(-screenLimit, transform.position.y, transform.position.z);
        }
    }
}
