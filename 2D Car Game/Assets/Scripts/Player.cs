using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    ObstacleSpawner obstacleSpawner;

    //a variale that can later be edited from unity
    [SerializeField] float horizontalPlayerSpeed = 10f; // speed float = 10
    [SerializeField] AudioClip playerDieSound;
    [SerializeField] [Range(0, 1)] float playeVolumeSound = 0.75f; //allows the variable to be set in the Inspector from 0 to 1
    [SerializeField] GameObject deathVFX;

    //Variables
    [SerializeField] float health = 50;
    float min;
    float max;

    // Start is called before the first frame update
    void Start()
    {
        SetUpBond();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//move function
    }

    void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * horizontalPlayerSpeed; //Move Left and Right
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, min, max);

        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);

    }

    void SetUpBond()
    {
        Camera gamecam = Camera.main;
        float border = 0.5f;

        min = gamecam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + border;
        max = gamecam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - border;
    }

    //reduces health whenever Player collides with gameobject and reduces health accordingly
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        //if there is no damageDealer in otherObjectm end the method
        if (!damageDealer) //if (!damageDealer == null)

            return;

        ProcessHit(damageDealer);
    }

    //Whenever the ProcessHit() is called, send us the DamageDealer details
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.hit();
        AudioSource.PlayClipAtPoint(playerDieSound, Camera.main.transform.position, playeVolumeSound);

        if (health <= 0)
        {
            GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
            die();
            Destroy(gameObject); //destroy player
        }
    }

    private void die()
    {
        AudioSource.PlayClipAtPoint(playerDieSound, Camera.main.transform.position, playeVolumeSound);
        FindObjectOfType<Level>().LoadGameOver(); //find the object of type level in Hierarchy and run its method LoadGameOver()

        Destroy(gameObject);
    }

    public float GetHealth()
    {
        return health;
    }

    public GameObject DeathVfx()
    {
        return deathVFX;
    }
}

