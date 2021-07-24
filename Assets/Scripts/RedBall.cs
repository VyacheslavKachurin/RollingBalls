using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : GreenBall
{
    private float chaseSpeed=4f;
    private GameObject[] ballsToChase;
    private int index;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        ballsToChase = GameObject.FindGameObjectsWithTag("GreenBall");
        GetRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.pauseGame)
        {
            Chase();
        }
    }
    private void GetRandomTarget()
    {
        index = Random.Range(0, ballsToChase.Length);
        target = ballsToChase[index].transform.position;
       
    }
    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, chaseSpeed * Time.deltaTime);
        if ((Vector2)transform.position == target)
        {
            GetRandomTarget();
        }
    }
}
