using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SwordQuench : MonoBehaviour
{

    //variables
    public Material coolMaterial;
    public Material hotMaterial;
    public bool isCool;
    [SerializeField] private int cooldownTime;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        //When the object is first loaded, set paramaters
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = hotMaterial;
        isCool = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //If overlapping object has the "QBucket" (Short for Quenching Bucket) tag, then change material and set isCool to true.
        if (other.gameObject.CompareTag("QBucket"))
        {
            meshRenderer.material = coolMaterial;
            isCool = true;
        }
        
    }
    
}
