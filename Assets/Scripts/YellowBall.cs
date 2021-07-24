using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBall : MonoBehaviour
{
    public Transform targetBall;
    private LineRenderer lineRenderer;
    private float speed = 2f;
    private BallDragging ballDragging;
    // Start is called before the first frame update
    void Start()
    {
        ballDragging = GetComponent<BallDragging>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
        EraseLine();
        if (!GameManager.pauseGame)
        {
            Move();

        }
    }
    private void DrawLine()
    {
        if (lineRenderer != null&&targetBall!=null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, targetBall.position);
        }
       
    }
    private void Move()
    {
        if (!ballDragging.stay)
        {
            if (targetBall != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetBall.position, speed * Time.deltaTime);
            }
        }
    }
    private void EraseLine()
    {
        if (targetBall == null&&lineRenderer!=null)
        {
            lineRenderer.SetPosition(1, transform.position);
        }
    }

}
