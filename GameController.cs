using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ballPrefab;
    public Text score1Text;
    public Text score2Text;
    public float scoreCoords = 3.4f;

    private Ball currentBall;
    private int score1 = 0;
    private int score2 = 0;

    // Use this for initialization
    void Start()
    {
        spawnBall();
    }

    void spawnBall()
    {
        GameObject ballInstance = Instantiate(ballPrefab, transform);
        currentBall = ballInstance.GetComponent<Ball>();
        currentBall.transform.position = Vector3.zero;
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBall != null)
        {
            if (currentBall.transform.position.x > scoreCoords)
            {
                score1++;
                Destroy(currentBall.gameObject);
                spawnBall();
            }
            if (currentBall.transform.position.x < -scoreCoords)
            {
                score2++;
                Destroy(currentBall.gameObject);
                spawnBall();
            }
        }
    }
}
