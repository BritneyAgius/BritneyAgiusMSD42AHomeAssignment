using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variable that cab be edited from unity
    [SerializeField] float movementSpeed = 5f;


    float xMin, xMax, yMin, yMax;
    float padding = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //takes care of movement in x-axis
    private void Move()
    {
        //get the movement on the x-axis
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        //set the x pos to the current position + deltaX
        var newXPos = transform.position.x + deltaX;
        //update the Player position 
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);


        transform.position = new Vector2(newXPos, transform.position.y);
    }
}

   