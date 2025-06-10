using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmithableItem : MonoBehaviour
{
    //Variables
    private bool canSmith;
    private bool onAnvil;
    public float requiredHammerVelocity = 0;
    //External Script references
    public GetHammerSpeed getHammerSpeed;
    public GameObject findpedestal;
    public FindRecipe findRecipe;
    public SmeltableItem smeltableItem;

    //Functions
    private void Update()
    {
        //Detect if Both Parent Object and Recipe are in the correct places
        if (onAnvil && findRecipe.recipeOnAnvil && smeltableItem.isWorkable)
        {
            canSmith = true;
            Debug.Log("penis");
        }    
    }
    private void Start()
    {
        findRecipe = FindFirstObjectByType<FindRecipe>();
        smeltableItem = GetComponent<SmeltableItem>();
    }
    //Smithing conditions
    private void OnTriggerEnter(Collider other)
    {
        //Check if Parent Object is on Anvil
        if (other.gameObject.CompareTag("Anvil"))
        {
            onAnvil = true;
            Debug.Log("Penis once more");
        }
            
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
        if (other.gameObject.CompareTag("Hammer") && canSmith)
            WhenSmithed();
    }
    private void WhenSmithed()
    {
        canSmith = false;
        //Spawn new Prefab Instance of the recipe's output and destroy parent
        Destroy(gameObject);
        GameObject newInstance = Instantiate(findRecipe.curentRecipe, transform.position, Quaternion.identity);
    }
}    