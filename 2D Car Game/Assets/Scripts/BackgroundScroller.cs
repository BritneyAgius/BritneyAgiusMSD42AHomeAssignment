using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float BackgroundScrollSpeed = 0.5f;

    //the Material from the texture
    Material myMaterial;

    //movement offset
    Vector2 offset;

    //start is called before the first frame update
    void Start()
    {
        //get the Material of the background from Renderer component
        myMaterial = GetComponent<Renderer>().material;

        //move in the y-axis at the given speed
        offset = new Vector2(0f, BackgroundScrollSpeed);
    }

    //update is called once per frame
    void Update()
    {
        //move the texture of the material by offset every frame
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
