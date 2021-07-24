using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : MonoBehaviour
{
    private BallDragging ballDragging;
    private float speed = 2f;
    private float randomX;
    private float randomY;
    private float step = 0.1f;
    protected Vector2 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        ballDragging = GetComponent<BallDragging>();
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.pauseGame)
        {
            RandomMovement();
        }
    }
    protected Vector2 GetRandomPosition()
    {
        randomX = Random.Range(Border.minX+step, Border.maxX-step);
        randomY = Random.Range(Border.minY+step, Border.maxY-step);
        return new Vector2(randomX, randomY);
    }
    protected void RandomMovement()
    {
        if (ballDragging.touched)
        {
            targetPosition = GetRandomPosition();
            ballDragging.touched = false;
        }
        if (!ballDragging.stay)
        {
            if ((Vector2)transform.position != targetPosition)
            {

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                targetPosition = GetRandomPosition();
            }
            
        }
        
    }
}
