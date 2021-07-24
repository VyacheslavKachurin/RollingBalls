using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 velocity=Vector2.zero;
    private Rigidbody2D projectileRb;
    private bool velocitySaved;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.pauseGame)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    private void Start()
    {
        projectileRb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GreenBall")
        {
            Destroy(gameObject);
        }
    }
}
