using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHammerSpeed : MonoBehaviour
{

    // variables
    
    private Rigidbody rb;
    public float hammerYVelocity;
    void Update()
    {
        hammerYVelocity = rb.velocity.y;
    }
}
