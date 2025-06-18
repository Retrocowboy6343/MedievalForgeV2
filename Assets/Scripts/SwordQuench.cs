using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SwordQuench : MonoBehaviour
{

    //variables
    public Material coolMaterial;
    public Material hotMaterial;
    private bool isCool;
    [SerializeField] private int cooldownTime;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        OnObjectSpawn();
        isCool = false;
    }   

    void OnObjectSpawn()
    {
        CooldownTimer();
        meshRenderer.materials[0] = hotMaterial;
    }
    
    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldownTime);
        OnCooldown();
    }
    private void OnCooldown()
    {
        meshRenderer.materials[0] = coolMaterial;
        isCool = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Qbucket"))
        {
            OnCooldown();
        }
    }
}
