using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f; //background is 'scrolled' creating the illusion that the player is driving on the road
    Material myMaterial; //texture material
    Vector2 offSet; //movement

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material; //Rendered Component - Background Material
        offSet = new Vector2(0f, backgroundScrollSpeed); //y-axis scrolling
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
