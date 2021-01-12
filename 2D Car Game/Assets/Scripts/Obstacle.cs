using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Obstacle Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 50;

    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject obstacleLaserPrefab;

    [Header("Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    [SerializeField] AudioClip obstacleDeathSound;
    [SerializeField] [Range(0, 1)] float obstacleDeathSoundVolume = 0.75f;

    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    [SerializeField] float obstacleLaserSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        //every frame reduces the amount of time that the frame takes to run
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            ObstacleFire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    //same as Player Fire() method
    private void ObstacleFire()
    {
        GameObject obstacleLaser = Instantiate(obstacleLaserPrefab, transform.position, Quaternion.identity) as GameObject;
        //obstacle laser shoots downwards, hence -obstacleLaserSpeed
        obstacleLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleLaserSpeed);

        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    //reduces health whenever obstacle collides with a gameObject which has DamageDealer component
    private void OnTriggerEnter2D(Collider2D other)
    {
        //access the Damage Dealer from the "other" object which hit the obstacle
        //and depending on the laser damage reduce health
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        //if there is no damageDealer on Collision
        //end the method
        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    //whenever ProcessHit is called send us the DamageDealer details
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        //destroy the laser that hits the Obstacle
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //add score to GameSession score
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        //destroy Obstacle ship
        Destroy(gameObject);
        //create an explosion particle
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy after 1 sec
        Destroy(explosion, explosionDuration);
        //play the obstacleDeathSound, at the position of the Camera, with the given volume
        AudioSource.PlayClipAtPoint(obstacleDeathSound, Camera.main.transform.position, obstacleDeathSoundVolume);
    }
}