using UnityEngine;

public class FindRecipe : MonoBehaviour
{
    public GameObject curentRecipe;
    public bool recipeOnAnvil;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Recipe"))
        {
            if (other.GetComponent<RecipeItem>().smithingOutput == null)
                return;

            if (other.GetComponent<RecipeItem>().smithingOutput != null)
            {
                curentRecipe = other.GetComponent<RecipeItem>().smithingOutput;
                recipeOnAnvil = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Recipe"))
        {
            curentRecipe = null;
            recipeOnAnvil = false;
        }
    }
}
