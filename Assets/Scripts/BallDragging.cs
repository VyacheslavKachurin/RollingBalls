using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDragging : MonoBehaviour
{
    public bool draggingAllowed = false;
    private int index;
    public bool stay = false;
    public bool touched = false;
    private GameManager gameManager;

    public ParticleSystem touchParticle;
    public ParticleSystem deathParticle;
    public AudioClip[] deathSounds;
    public AudioClip[] touchSounds;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
    }
    protected void TouchEffects()
    {
        if (!GameManager.pauseGame)
        {
            Instantiate(touchParticle, transform.position, Quaternion.identity);
            index = Random.Range(0, touchSounds.Length);

            if (GameManager.isSoundsOn)
            {
                audioSource.clip = touchSounds[index];
                audioSource.Play();
            }
        }
       
    }
    protected void Deathffects()
    {
        CameraShake.Shake();
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathSounds[index], new Vector3(0, 0, -9), 1f);
        Destroy(gameObject);
    }

    public void TurnDraggingOn(int i)
    {
        TouchEffects();
        draggingAllowed = true;
        index = i;
}
    public void TurnDraggingOff()
    {
        draggingAllowed = false;
    }
    
    public void MoveBall()
    {
        
        if (draggingAllowed&&!GameManager.pauseGame)
        {
            try
            {

                Touch touch = Input.GetTouch(index);
                if (touch.phase == TouchPhase.Moved)
                {

                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    transform.position = touchPosition;
                    
                }
                if (touch.phase == TouchPhase.Stationary)
                {
                    stay = true;
                }
                if (touch.phase != TouchPhase.Stationary)
                {
                    stay = false;
                }


                if (Input.GetTouch(index).phase == TouchPhase.Ended)
                {
                    TurnDraggingOff();
                    touched = true;
                }
            }
            catch
            {
                TurnDraggingOff();
            }
}
        
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Deathffects();
        Destroy(gameObject);
        gameManager.LoseLevel();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Deathffects();
        Destroy(gameObject);
        gameManager.LoseLevel();
    }


}
