using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBall : MonoBehaviour
{
    private GameObject[] ballsToShoot;

    private int index;
    private Vector3 targetBall;
    private float turnSpeed = 3f;
    public GameObject projectilePrefab;
    private float projectileSpeed=5f;
    private bool isShooting;
    private float timer;
    private float timerReset=1f;
    private Vector3 targetDirection;

    // Start is called before the first frame update
    void Start()
    {
        ballsToShoot = GameObject.FindGameObjectsWithTag("GreenBall");
        GetRandomIndex();
        timer = timerReset;
    }
   

    // Update is called once per frame
    void Update()
    {

        Aim();
    }
    private void FixedUpdate()
    {
        Shoot();
    }
   
    private void Aim()
    {
        timer -= Time.deltaTime;
        targetDirection = GetTarget() - transform.position;
        
        Quaternion wantedRotation = Quaternion.LookRotation(Vector3.forward,targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, turnSpeed * Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, wantedRotation) < 5&&timer<0)
        {
            
            
                isShooting = true;
            
        }
        else
        {
            isShooting = false;
        }
     
    }
    private Vector3 GetTarget()
    {
        if (ballsToShoot[index] != null)
        {
            targetBall = ballsToShoot[index].transform.position;

            return targetBall;

        }
        else
        {
            GetRandomIndex();

        }
        return Vector3.zero;
        
    }
    private void GetRandomIndex()
    {
        index = Random.Range(0, ballsToShoot.Length);
        
    }
    private void Shoot()
    {
        if (isShooting)
        {
            
                GameObject shot = Instantiate(projectilePrefab, transform.position+transform.up, Quaternion.identity);
                isShooting = false;
                timer = timerReset;
                shot.GetComponent<Rigidbody2D>().velocity = targetDirection.normalized * projectileSpeed;
            GetRandomIndex();
                Destroy(shot, 3f);
            

        }
    }
   
}
