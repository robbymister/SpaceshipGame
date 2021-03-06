using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneManager3DSpace : MonoBehaviour
{
    public Text infoText;
    public Player3D player;

    // Start is called before the first frame update
    void Start()
    {
        //SimpleGesture.OnTap(OnTap);
    }

    private void OnTap()
    {
       // Debug.Log("Tap!");
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = "No input detected.";
        
        List<Vector2> touchCoordinates = new List<Vector2>();

        // For use in mobile.
        foreach (Touch touch in Input.touches)
        {
            touchCoordinates.Add(touch.position);
        }

        // Dummy touches start.
        if (Input.GetMouseButton(0))
        {
            touchCoordinates.Add(Input.mousePosition);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            touchCoordinates.Add(new Vector2(42,100));
        }
        if (Input.GetKey(KeyCode.V))
        {
            touchCoordinates.Add(new Vector2(1337, 42));
        }
        // Dummy touches end.

        // Print input info on screen
        if (touchCoordinates.Count > 0)
        {
            infoText.text = "";
            for (int i = 0; i < touchCoordinates.Count; i++)
            {
                infoText.text += string.Format("Input {0}: {1}, {2} \n",i+1,(int)touchCoordinates[i].x,(int)touchCoordinates[i].y);
            }
        }
        // Activate power-ups.
        if (touchCoordinates.Count == 2)
        {
            player.ActivateSpeedUp();
        } else if (touchCoordinates.Count == 3)
        {
            player.ActivateInvicibility();
        }
    }
}
