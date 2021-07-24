using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : OrangeBall
{
    public GameObject shotPrefab;
    public Transform[] placeHolders;
    private int placeIndex;
    private Vector2 targetToMove;
    private GameObject[] ballsToShoot;
    private Vector3 targetToShoot;
    private Vector2 target;
    private float purpleSpeed = 3f;
    private float projectileSpeed=7f;
    private bool isShooting = false;
    private int index;
    

    
    
  
    

    private void Start()
    {
        ballsToShoot=FindTargets();
        targetToMove = RandomPosition();
        targetToShoot = GetTargetToAim(ballsToShoot);

    }
    private void MoveAround()
    {
        
            if ((Vector2)transform.position != targetToMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetToMove, purpleSpeed * Time.deltaTime);
            }
            if ((Vector2)transform.position == targetToMove)
            {
            targetToMove = RandomPosition();
            isShooting = true;
        }

            }
        
        
    
    private void FixedUpdate()
    {
        if (!GameManager.pauseGame)
        {
            Shoot();
        }
        
    }
  

    Vector2 RandomPosition()
    {
        placeIndex = Random.Range(0, placeHolders.Length);
        target = placeHolders[placeIndex].position;
        return target;
    }
    private void Update()
    {
        if (!GameManager.pauseGame)
        {
            MoveAround();
        }

    }
    private void DeathEffect()
    {

    }
    private void TouchEffect()
    { }
    protected Vector2 GetTargetToAim(GameObject[] ballsToShoot)
    {
        index = Random.Range(0, ballsToShoot.Length);
        targetToShoot = ballsToShoot[index].transform.position;
        return targetToShoot;
    }
    protected void Shoot()
    {
        if (isShooting)
        {
            
            
            try
            {
                
                if (targetToShoot != null)
                {
                    GameObject projectile = Instantiate(shotPrefab, transform.position, Quaternion.identity);
                    Vector2 direction = targetToShoot - projectile.transform.position;
                    
                    
                        projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectileSpeed;
                    
                    isShooting = false;
                   // timer =resetTimer;
                    
                    Destroy(projectile, 3);
                   
                    targetToShoot = GetTargetToAim(ballsToShoot);


                }
            }
            catch
            {

            }
            
            
        }

    }
    protected GameObject[] FindTargets()
    {
        ballsToShoot = GameObject.FindGameObjectsWithTag("GreenBall");
        return ballsToShoot;
    }
  

  

}
