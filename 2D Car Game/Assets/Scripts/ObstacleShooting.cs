using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShooting : MonoBehaviour
{
    //Declaring variables that can be changed in unity
    [SerializeField] float amountShot;
    [SerializeField] float minTime = 0.2f;
    [SerializeField] float maxTime = 3f;
    [SerializeField] float obstacleLaserSpeed = 20f;
    [SerializeField] GameObject obstacleLaserPrefab = null;

    waveConfig waveConfig;

    void Start()
    {
        amountShot = Random.Range(minTime, maxTime);//fire at random min and max time 
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

            amountShot = Random.Range(minTime, maxTime);
        }
    }

    void ObstacleFire()
    {
        GameObject enemyLaserClone = Instantiate(obstacleLaserPrefab, transform.position, Quaternion.Euler(0, 0, 180));//obstacle shoots laser downward 
        enemyLaserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleLaserSpeed);//laser speed
    }
}
