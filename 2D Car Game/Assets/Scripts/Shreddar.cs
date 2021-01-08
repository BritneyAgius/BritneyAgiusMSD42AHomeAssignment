using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreddar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        print("Collision with " + otherObject.name);
    }
}
