using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //declaring variables thhat can later be changed from unity
    [SerializeField] float Shotcounter;
    [SerializeField] float minTime = 0.2f;
    [SerializeField] float maxTime = 3f;
    [SerializeField] GameObject obstacleLaserPrefab = null;
    [SerializeField] float obstacleLaserSpeed = 20f;

    waveConfig waveConfig;
    
    void Start()
    {
        Shotcounter = Random.Range(minTime, maxTime);//fire at random min and max time 
    }

    // Update is called once per frame
    void Update()
    {
        CountDownThenShoot();
    }


    void CountDownThenShoot()
    {
        Shotcounter -= Time.deltaTime;

        if (Shotcounter <= 0)
        {
            ObstacleFire();

            Shotcounter = Random.Range(minTime, maxTime);
        }
    }

    void ObstacleFire()
    {
        GameObject obstacleLaserClone = Instantiate(obstacleLaserPrefab, transform.position, Quaternion.Euler(0, 0, 180));//obstacle shoots laser downward 
        obstacleLaserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleLaserSpeed);//laser speed
    }
}