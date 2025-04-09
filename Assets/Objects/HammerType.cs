using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class HammerType : ScriptableObject
{
    //variables
    private Rigidbody rb;
    private MeshRenderer mr;
    private Collider headCollider;
    private Collider handleCollider;
    private float smithingPower;
    private int smithingTier;
    private float hammerVelocity;
    private float desiredVerticalVelocity;
    public void OnIngotHit() 
    {
        hammerVelocity = rb.velocity.y;
        if(hammerVelocity > desiredVerticalVelocity)
        {

        }
    }
}
