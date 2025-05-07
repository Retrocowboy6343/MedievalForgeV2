using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeItem: MonoBehaviour
{
    //Variables
    public GameObject smithingOutput;
    public bool recipeOnAnvil;

    private void OnTriggerEnter(Collider other)
    {
        //Check if Parent Object is on the Anvil Pedistal
        if (other.gameObject.CompareTag("AnvilPedistal"))
        {
            recipeOnAnvil = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Check if Parent Object leaves the Anvil Pedistal
        if (other.gameObject.CompareTag("AnvilPedistal"))
        {
            recipeOnAnvil = false;
        }
    }
}
