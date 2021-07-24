using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBall : MonoBehaviour
{
    private GameObject[] objectToFollow;
    public float speed=3f;
    private int index;
    private BallDragging ballDragging;
    private Vector2 targetToFollow;
    // Start is called before the first frame update
    void Start()
    {
        ballDragging = GetComponent<BallDragging>();
        objectToFollow = GameObject.FindGameObjectsWithTag("GreenBall");
        targetToFollow = Target();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        targetToFollow = Target();
    }
    private void Follow()
    {
        if (!ballDragging.stay&&!GameManager.pauseGame)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetToFollow, speed * Time.deltaTime);
        }
        if (ballDragging.touched)
        {
            targetToFollow = Target();
            ballDragging.touched = false;
        }
    }
    private Vector2 Target()
    {
        try
        {


            if (targetToFollow == null)
            {
                index = Random.Range(0, objectToFollow.Length);
            }
            if (ballDragging.touched)
            {
                index = Random.Range(0, objectToFollow.Length);
            }
            return objectToFollow[index].transform.position;
        }
        catch
        {
            return Vector2.zero;
        }
    }
}
