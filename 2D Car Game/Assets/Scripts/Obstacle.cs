using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //initilizing and declaring variables
    [SerializeField] float amountShot;
    [SerializeField] float minTime = 0.2f;
    [SerializeField] float maxTime = 3f;
    [SerializeField] GameObject obstacleLaserPrefab = null;
    [SerializeField] float obstacleLaserSpeed = 20f;
    waveConfig waveConfig;
    void Start()
    {
        amountShot = Random.Range(minTime, maxTime);//make fire at random minimum and maximum time 
    }

    // Update is called once per frame
    void Update()
    {
        CountDownThenShoot();
    }


    void CountDownThenShoot()
    {
        amountShot -= Time.deltaTime;

        if (amountShot <= 0)
        {
            ObtsacleFire();

            amountShot = Random.Range(minTime, maxTime);//make fire at random minimum and maximum time
        }
    }

    void ObstacleFire()
    {
        GameObject obstacleLaserClone = Instantiate(obstacleLaserPrefab, transform.position, Quaternion.Euler(0, 0, 180));//obstacle laser go down 
        obstacleLaserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleLaserSpeed);//speed of laser
    }
}