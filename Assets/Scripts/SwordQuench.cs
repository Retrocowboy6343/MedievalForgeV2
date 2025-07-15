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
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        OnObjectSpawn();
        isCool = false;
        Debug.Log("Object Spawned correctly yes");

    }   

    void OnObjectSpawn()
    {
        CooldownTimer();
        meshRenderer.materials[0] = hotMaterial;
        Debug.Log(meshRenderer.materials[0]);
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
        if (other.gameObject.CompareTag("QBucket"))
        {
            OnCooldown();
        }
    }
}
