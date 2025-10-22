using UnityEngine;

public class FindRecipe : MonoBehaviour
{
    //Variables
    public GameObject curentRecipe;
    public bool recipeOnAnvil;

    //Detect if anything with a collider enters the Pedestal Trigger
    private void OnTriggerEnter(Collider other)
    {
        //Check if the the overlapping GameObject has the "Recipe" Tag
        if (other.gameObject.CompareTag("Recipe"))
        {
            //If the smithingOutput variable is null, return
            if (other.GetComponent<RecipeItem>().smithingOutput == null)
            {
                recipeOnAnvil = false;
                return;
            }
            //If smithingOutput isn't null, set currentRecipe to the smithingOutput variable and set recipeOnAnvil to true
            if (other.GetComponent<RecipeItem>().smithingOutput != null)
            {
                curentRecipe = other.GetComponent<RecipeItem>().smithingOutput;
                recipeOnAnvil = true;
                
            }
        }
    }
    //If recipe leaves the trigger, set currentRecipe to null and set recipeOnAnvil to false
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Recipe"))
        {

            curentRecipe = null;
            recipeOnAnvil = false;
        }
    }
}
