using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmithableItem : MonoBehaviour
{
    //Variables
    [SerializeField] private int smeltingTime;
    private bool isWorkable;
    private bool canSmith;
    private bool onAnvil;
    public float requiredHammerVelocity = 20;
    //External Script references
    public GetHammerSpeed getHammerSpeed;
    public RecipeItem getRecipe;
    
    //Functions
    private void Update()
    {
        //Detect if Both Parent Object and Recipe are in the correct places
        if (onAnvil && getRecipe.recipeOnAnvil && isWorkable)
            canSmith = true;
    }
    //Smithing conditions
    private void OnTriggerEnter(Collider other)
    {
        //Check if Parent Object is on Anvil
        if (other.gameObject.CompareTag("Anvil"))
            onAnvil = true;
        if (other.gameObject.CompareTag("BrickOven"))
        {
            StartCoroutine(WhenSmelted());
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        //Check if Parent Object leaves Anvil
        if (other.gameObject.CompareTag("Anvil"))
            onAnvil = false;
        if (other.gameObject.CompareTag("BrickOven") && !isWorkable)
        {
            StopCoroutine(WhenSmelted());
        }
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
    private IEnumerator WhenSmelted()
    {
        yield return new WaitForSeconds(smeltingTime);
        isWorkable = true;
    }
    private IEnumerator IngotAutoCooldown()
    {
        yield return new WaitForSeconds(20);
        isWorkable = false;
    }
    private void WhenQuenched()
    {
        StopCoroutine(IngotAutoCooldown());
        isWorkable = false;
    }
}