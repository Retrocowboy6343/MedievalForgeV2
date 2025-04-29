using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmithableItem : MonoBehaviour
{
    //Variables
    private bool canSmith;
    private bool onAnvil;
    public float requiredHammerVelocity = 20;
    //External Script references
    public GetHammerSpeed getHammerSpeed;
    public RecipeItem getRecipe;
    
    private void Update()
    {
        //Detect if Both Parent Object and Recipe are in the correct places
        if (onAnvil && getRecipe.recipeOnAnvil)
            canSmith = true;
    }
    //Smithing conditions
    private void OnTriggerEnter(Collider other)
    {
        //Check if Parent Object is on Anvil
        if (other.gameObject.CompareTag("Anvil"))
            onAnvil = true;
    }
    private void OnTriggerExit(Collider other) 
    {
        //Check if Parent Object leaves Anvil
        if (other.gameObject.CompareTag("Anvil"))
            onAnvil = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        //If all smithing conditions are met, run WhenSmithed()
        if (other.gameObject.CompareTag("Hammer") && getHammerSpeed.hammerYVelocity >= requiredHammerVelocity && canSmith)
            WhenSmithed();
    }
    private void WhenSmithed()
    {
        //Spawn new Prefab Instance of the recipe's output
        GameObject newInstance = Instantiate(getRecipe.smithingOutput, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //Destroy Parent Object
        Debug.Log("Success!");
    }
}