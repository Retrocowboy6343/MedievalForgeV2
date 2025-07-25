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
    

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = hotMaterial;
        isCool = false;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Qbucket") && !isCool)
        {
            meshRenderer.material = coolMaterial;
            isCool = true;
        }
    }
}
