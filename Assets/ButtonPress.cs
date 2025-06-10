using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    //variables
    [SerializeField] GameObject spawnedObject;
    public Transform spawnTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            Instantiate(spawnedObject, spawnTransform);
        }
    }
}
