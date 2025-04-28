using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecipeItem : MonoBehaviour
{
    //variables
    public GameObject smithingOutput;
    private bool canSmith;
    private bool onAnvil;
    public GetHammerSpeed getHammerSpeed;

    private void Update()
    {
        if (getHammerSpeed.hammerYVelocity >= 20 && onAnvil)
            canSmith = true;
    }
    //smithing conditions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anvil"))
            onAnvil = true;
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Anvil"))
            onAnvil = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Hammer") && canSmith)
            WhenSmithed();
    }

    private void WhenSmithed()
    {
        GameObject newInstance = Instantiate(smithingOutput, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
   
}
