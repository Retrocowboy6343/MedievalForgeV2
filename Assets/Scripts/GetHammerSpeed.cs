using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHammerSpeed : MonoBehaviour
{
    //Variables
    [SerializeField] private Rigidbody rb;
    public float hammerYVelocity;

    void Update()
    {
        //Set hammerYVelocity to the Y velocity of the hammer
        hammerYVelocity = rb.linearVelocity.y;
    }
}
