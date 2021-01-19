using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShooting : MonoBehaviour
{
    //initilizing and declaring variables
    [SerializeField] float amountShot;
    [SerializeField] float minTime = 0.2f;
    [SerializeField] float maxTime = 3f;
    [SerializeField] float obstacleLaserSpeed = 20f;
    [SerializeField] GameObject obstacleLaserPrefab = null;

    waveConfig waveConfig;

    void Start()
    {
        amountShot = Random.Range(minTime, maxTime);//make fire at random minimum and maximum time 
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }


    void CountDownAndShoot()
    {
        amountShot -= Time.deltaTime;

        if (amountShot <= 0)
        {
            ObstacleFire();

            amountShot = Random.Range(minTime, maxTime);//make fire at random minimum and maximum time
        }
    }

    void ObstacleFire()
    {
        GameObject enemyLaserClone = Instantiate(obstacleLaserPrefab, transform.position, Quaternion.Euler(0, 0, 180));//enemy laser go down 
        enemyLaserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleLaserSpeed);//speed of laser
    }
}
