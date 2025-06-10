using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    //variables
    [SerializeField] GameObject spawnedObject;
    public Transform spawnTransform;
    public void WhenButtonPressed()
    {
        Instantiate(spawnedObject, spawnTransform);
    }
}
